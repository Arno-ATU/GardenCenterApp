using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using GardenApp.Models;
using GardenApp.Services;

namespace GardenApp.ViewModels
{
    public class HandToolsViewModel:BaseViewModel
    {
        private readonly CartService _cartService;
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public HandToolsViewModel(CartService cartService)
        {
            _cartService = cartService;
            LoadProducts();
            GoBackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
            AddToCartCommand = new Command<string>(OnAddToCart);
        }

        private void LoadProducts()
        {
            try
            {
                var jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "Products.json");
                var jsonString = File.ReadAllText(jsonPath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var productData = JsonSerializer.Deserialize<ProductCatalog>(jsonString, options);

                var toolsCategory = productData?.Categories?.FirstOrDefault(c => c.Name == "Tools");
                var handToolsSubcategory = toolsCategory?.Subcategories?.FirstOrDefault(sc => sc.Name == "Hand Tools");

                var handTools = handToolsSubcategory?.Products?
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Category = "Tools",
                        Subcategory = "Hand Tools"
                    })
                    .ToList() ?? new List<Product>();

                Products = new ObservableCollection<Product>(handTools);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products: {ex.Message}");
                Products = new ObservableCollection<Product>();
            }
        }

        private void OnAddToCart(string productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _cartService.AddToCart(product);
                Application.Current.MainPage.DisplayAlert("Added to Cart", $"{product.Name} added to your cart", "OK");
            }
        }
    }
}
