using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class PestControlPage:ContentPage
    {
        public PestControlPage(PestControlViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
