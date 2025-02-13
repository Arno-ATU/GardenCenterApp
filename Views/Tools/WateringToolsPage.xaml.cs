using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class WateringToolsPage:ContentPage
    {
        public WateringToolsPage(WateringToolsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
