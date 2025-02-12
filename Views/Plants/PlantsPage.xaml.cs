using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class PlantsPage:ContentPage
    {
        public PlantsPage()
        {
            InitializeComponent();
            BindingContext = new PlantsViewModel();
        }
    }
}
