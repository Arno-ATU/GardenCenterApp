using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class HandToolsPage:ContentPage
    {
        public HandToolsPage(HandToolsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
