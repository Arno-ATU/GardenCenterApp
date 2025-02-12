using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class GardenCarePage:ContentPage
    {
        public GardenCarePage()
        {
            InitializeComponent();
            BindingContext = new GardenCareViewModel();
        }
    }
}
