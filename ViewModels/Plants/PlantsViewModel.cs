using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class PlantsViewModel
    {
        public ICommand NavigateCommand { get; }

        public PlantsViewModel()
        {
            NavigateCommand = new Command<string>(async (route) =>
            {
                try
                {
                    Console.WriteLine($"Debug: Navigation attempted for route: {route}");

                    string navigationRoute = route.ToLower() switch
                    {
                        "indoorplants" => "plants/indoor-plants",  // Remove the // at start
                        "outdoorplants" => "plants/outdoor-plants",
                        "seasonalplants" => "plants/seasonal-plants",
                        _ => throw new ArgumentException($"Unknown route: {route}")
                    };

                    Console.WriteLine($"Debug: Converted to navigation route: {navigationRoute}");
                    await Shell.Current.GoToAsync(navigationRoute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Navigation error: {ex.Message}");
                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
                }
            });
        }
    }
}
