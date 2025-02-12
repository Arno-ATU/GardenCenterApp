using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }

        public ProductViewModel()
        {
            Products = new List<Product>();
        }
    }
}
