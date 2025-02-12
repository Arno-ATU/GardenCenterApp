using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class FertilizersViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public FertilizersViewModel()
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

                // Configure JSON deserialization options
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize the JSON
                var productData = JsonSerializer.Deserialize<ProductCatalog>(jsonString, options);

                // Find the Garden Care category
                var gardenCareCategory = productData.Categories
                    .FirstOrDefault(c => c.Name == "Garden Care");

                // Find Fertilizers subcategory
                var fertilizersSubcategory = gardenCareCategory.Subcategories
                    .FirstOrDefault(sc => sc.Name == "Fertilizers");

                // Map JSON products to Product instances
                var fertilizers = fertilizersSubcategory.Products
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Category = "Garden Care",
                        Subcategory = "Fertilizers"
                    })
                    .ToList();

                // Log fertilizers details
                System.Diagnostics.Debug.WriteLine($"Total Fertilizers: {fertilizers.Count}");
                foreach (var product in fertilizers)
                {
                    System.Diagnostics.Debug.WriteLine($"Fertilizer: {product.Name}, Price: {product.Price}");
                }

                // Convert to ObservableCollection
                Products = new ObservableCollection<Product>(fertilizers);
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
