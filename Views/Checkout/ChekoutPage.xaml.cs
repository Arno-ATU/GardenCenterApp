using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class CheckoutPage:ContentPage
    {
        public CheckoutPage(CheckoutViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
