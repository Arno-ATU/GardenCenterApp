using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class FertilizersPage:ContentPage
    {
        public FertilizersPage(FertilizersViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
