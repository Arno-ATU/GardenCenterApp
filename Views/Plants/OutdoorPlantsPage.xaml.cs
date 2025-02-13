using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class OutdoorPlantsPage:ContentPage
    {
        public OutdoorPlantsPage(OutdoorPlantsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
