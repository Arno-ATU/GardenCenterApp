using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class OutdoorPlantsViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public OutdoorPlantsViewModel()
        {
            LoadProducts();
            GoBackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
            AddToCartCommand = new Command<string>(AddToCart);
        }

        private void LoadProducts()
        {
            try
            {
                // Use application base directory and combine with relative path
                var jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "Products.json");

                // More detailed logging
                System.Diagnostics.Debug.WriteLine($"Attempting to read JSON from: {jsonPath}");
                System.Diagnostics.Debug.WriteLine($"File exists: {File.Exists(jsonPath)}");

                // Read the JSON file
                var jsonString = File.ReadAllText(jsonPath);

                // Log the entire JSON content for debugging
                System.Diagnostics.Debug.WriteLine($"Full JSON Content:\n{jsonString}");

                // Configure JSON deserialization options
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize the JSON
                var productData = JsonSerializer.Deserialize<ProductCatalog>(jsonString, options);

                // Log deserialization details
                System.Diagnostics.Debug.WriteLine($"Total Categories: {productData?.Categories?.Count ?? 0}");

                // Null checks and detailed logging
                if (productData?.Categories == null)
                {
                    System.Diagnostics.Debug.WriteLine("No categories found in the JSON");
                    Products = new ObservableCollection<Product>();
                    return;
                }

                // Find the Plants category
                var plantsCategory = productData.Categories
                    .FirstOrDefault(c => c.Name == "Plants");

                if (plantsCategory == null)
                {
                    System.Diagnostics.Debug.WriteLine("No 'Plants' category found");
                    Products = new ObservableCollection<Product>();
                    return;
                }

                // Log subcategories
                System.Diagnostics.Debug.WriteLine($"Total Subcategories: {plantsCategory.Subcategories?.Count ?? 0}");

                // Find Outdoor Plants subcategory
                var outdoorPlantsSubcategory = plantsCategory.Subcategories?
                    .FirstOrDefault(sc => sc.Name == "Outdoor Plants");

                if (outdoorPlantsSubcategory == null)
                {
                    System.Diagnostics.Debug.WriteLine("No 'Outdoor Plants' subcategory found");
                    Products = new ObservableCollection<Product>();
                    return;
                }

                // Map JSON products to Product instances
                var outdoorPlants = outdoorPlantsSubcategory.Products?
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Category = "Plants",
                        Subcategory = "Outdoor Plants"
                    })
                    .ToList() ?? new List<Product>();

                // Log outdoor plants details
                System.Diagnostics.Debug.WriteLine($"Total Outdoor Plants: {outdoorPlants.Count}");
                foreach (var plant in outdoorPlants)
                {
                    System.Diagnostics.Debug.WriteLine($"Plant: {plant.Name}, Price: {plant.Price}");
                }

                // Convert to ObservableCollection
                Products = new ObservableCollection<Product>(outdoorPlants);
            }
            catch (Exception ex)
            {
                // Comprehensive error logging
                System.Diagnostics.Debug.WriteLine($"Error loading products: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                Products = new ObservableCollection<Product>();
            }
        }

        private void AddToCart(string productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Application.Current.MainPage.DisplayAlert("Added to Cart",
                    $"{product.Name} added to your cart", "OK");
            }
        }
    }
}
