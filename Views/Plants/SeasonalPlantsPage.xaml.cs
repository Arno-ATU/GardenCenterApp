using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class SeasonalPlantsPage:ContentPage
    {
        public SeasonalPlantsPage(SeasonalPlantsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
