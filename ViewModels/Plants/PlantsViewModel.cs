using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class PlantsViewModel
    {
        public ICommand NavigateCommand { get; }
        public List<Plant> Plants { get; set; }

        public PlantsViewModel()
        {
            Plants = new List<Plant>();
            NavigateCommand = new Command<string>(async (route) =>
            {
                try
                {
                    Console.WriteLine($"Attempting navigation to: {route}");
                    string navigationRoute = route.ToLower() switch
                    {
                        "indoorplants" => "//indoor-plants",
                        _ => throw new ArgumentException($"Unknown route: {route}")
                    };

                    await Shell.Current.GoToAsync(navigationRoute);
                    Console.WriteLine($"Navigation completed to: {navigationRoute}");
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
