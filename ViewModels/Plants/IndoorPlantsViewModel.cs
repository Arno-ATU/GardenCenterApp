using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class IndoorPlantsViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public IndoorPlantsViewModel()
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

                // Find Indoor Plants subcategory
                var indoorPlantsSubcategory = plantsCategory.Subcategories?
                    .FirstOrDefault(sc => sc.Name == "Indoor Plants");

                if (indoorPlantsSubcategory == null)
                {
                    System.Diagnostics.Debug.WriteLine("No 'Indoor Plants' subcategory found");
                    Products = new ObservableCollection<Product>();
                    return;
                }

                // Map JSON products to Product instances
                var indoorPlants = indoorPlantsSubcategory.Products?
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Category = "Plants",
                        Subcategory = "Indoor Plants"
                    })
                    .ToList() ?? new List<Product>();

                // Log indoor plants details
                System.Diagnostics.Debug.WriteLine($"Total Indoor Plants: {indoorPlants.Count}");
                foreach (var plant in indoorPlants)
                {
                    System.Diagnostics.Debug.WriteLine($"Plant: {plant.Name}, Price: {plant.Price}");
                }

                // Convert to ObservableCollection
                Products = new ObservableCollection<Product>(indoorPlants);
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

    // Temporary classes for JSON deserialization
    public class ProductCatalog
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }

    public class Subcategory
    {
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
    }

    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
