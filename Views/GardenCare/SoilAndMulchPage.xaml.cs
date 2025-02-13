using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class SoilAndMulchPage:ContentPage
    {
        public SoilAndMulchPage(SoilAndMulchViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
