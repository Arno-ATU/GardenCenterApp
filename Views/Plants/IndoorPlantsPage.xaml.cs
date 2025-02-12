using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class IndoorPlantsPage:ContentPage
    {
        public IndoorPlantsPage()
        {
            InitializeComponent();
            BindingContext = new IndoorPlantsViewModel();
        }
    }
}
