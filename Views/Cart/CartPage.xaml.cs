using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class CartPage:ContentPage
    {
        public CartPage(CartViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
