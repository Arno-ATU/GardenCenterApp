using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class IndoorPlantsPage:ContentPage
    {
        public IndoorPlantsPage(IndoorPlantsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
