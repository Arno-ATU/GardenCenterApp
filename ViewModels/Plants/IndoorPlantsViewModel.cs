using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class IndoorPlantsViewModel
    {
        public List<Plant> IndoorPlants { get; set; }
        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public IndoorPlantsViewModel()
        {
            // Initialize commands
            GoBackCommand = new Command(async () => await GoBack());
            AddToCartCommand = new Command<string>(async (productId) => await AddToCart(productId));

            // Initialize products (we'll load from JSON later)
            IndoorPlants = new List<Plant>
            {
                new Plant
                {
                    Id = "IP001",
                    Name = "Peace Lily",
                    Description = "Beautiful flowering indoor plant, perfect for low-light areas",
                    Price = 24.99m,
                    Subcategory = "Indoor Plants"
                },
                new Plant
                {
                    Id = "IP002",
                    Name = "Snake Plant",
                    Description = "Hardy indoor plant that helps purify air",
                    Price = 19.99m,
                    Subcategory = "Indoor Plants"
                },
                new Plant
                {
                    Id = "IP003",
                    Name = "Pothos",
                    Description = "Easy-care trailing plant with variegated leaves",
                    Price = 15.99m,
                    Subcategory = "Indoor Plants"
                }
            };
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task AddToCart(string productId)
        {
            var product = IndoorPlants.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                // We'll implement cart functionality later
                await Shell.Current.DisplayAlert("Added to Cart",
                    $"{product.Name} has been added to your cart.", "OK");
            }
        }
    }
}
