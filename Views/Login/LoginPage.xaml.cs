using GardenApp.ViewModels;

namespace GardenApp.Views
{
    public partial class LoginPage:ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
