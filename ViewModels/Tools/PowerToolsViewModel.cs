using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class PowerToolsViewModel:BaseViewModel
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public PowerToolsViewModel()
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

                // Find the Tools category
                var toolsCategory = productData.Categories
                    .FirstOrDefault(c => c.Name == "Tools");

                // Find Power Tools subcategory
                var powerToolsSubcategory = toolsCategory.Subcategories
                    .FirstOrDefault(sc => sc.Name == "Power Tools");

                // Map JSON products to Product instances
                var powerTools = powerToolsSubcategory.Products
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Category = "Tools",
                        Subcategory = "Power Tools"
                    })
                    .ToList();

                // Log power tools details
                System.Diagnostics.Debug.WriteLine($"Total Power Tools: {powerTools.Count}");
                foreach (var tool in powerTools)
                {
                    System.Diagnostics.Debug.WriteLine($"Tool: {tool.Name}, Price: {tool.Price}");
                }

                // Convert to ObservableCollection
                Products = new ObservableCollection<Product>(powerTools);
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
