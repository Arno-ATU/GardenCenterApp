using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class ToolsViewModel
    {
        public ICommand NavigateCommand { get; }
        public List<Tool> Tools { get; set; }

        public ToolsViewModel()
        {
            Tools = new List<Tool>();
            NavigateCommand = new Command<string>(async (route) =>
            {
                try
                {
                    // Ensure the route is lowercase and uses the correct path
                    string navigationRoute = route.ToLower() switch
                    {
                        "handtools" => "tools/hand-tools",
                        "powertools" => "tools/power-tools",
                        "wateringtools" => "tools/watering-tools",
                        _ => throw new ArgumentException($"Unknown route: {route}")
                    };

                    await Shell.Current.GoToAsync(navigationRoute);
                }
                catch (Exception ex)
                {
                    // Log the error
                    System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");

                    // Optionally show an error message to the user
                    await Application.Current.MainPage.DisplayAlert("Navigation Error",
                        $"Could not navigate to {route}", "OK");
                }
            });
        }
    }
}
