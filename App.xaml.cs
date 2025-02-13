using GardenApp.Services;

namespace GardenApp
{
    public partial class App:Application
    {
        public App(AuthService authService, AppShellViewModel appShellViewModel)
        {
            InitializeComponent();
            MainPage = new AppShell(appShellViewModel);

            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    Console.WriteLine("Attempting to navigate to login page...");
                    await Shell.Current.GoToAsync("//login");
                    Console.WriteLine("Navigation to login page completed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error navigating to login page: {ex.Message}");
                }
            });
        }
    }
}
