using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class PowerToolsPage:ContentPage
    {
        public PowerToolsPage(PowerToolsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
