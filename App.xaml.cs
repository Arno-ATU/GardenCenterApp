using GardenApp.Services;

namespace GardenApp
{
    public partial class App:Application
    {
        public App(AuthService authService, AppShellViewModel appShellViewModel)
        {
            InitializeComponent();
            MainPage = new AppShell(appShellViewModel);

            // Navigate to the login page when the app starts
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Shell.Current.GoToAsync("//login");
            });
        }
    }
}
