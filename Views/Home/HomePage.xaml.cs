using GardenApp.ViewModels;
using Microsoft.Maui.Controls;

namespace GardenApp.Views
{
    public partial class HomePage:ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}
