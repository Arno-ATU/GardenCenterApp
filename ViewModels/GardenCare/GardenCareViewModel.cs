using System.Windows.Input;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class GardenCareViewModel
    {
        public ICommand NavigateCommand { get; }
        public List<GardenCare> GardenCares { get; set; }

        public GardenCareViewModel()
        {
            NavigateCommand = new Command<string>(async (route) =>
            {
                try
                {
                    // Ensure here tthat the route is lowercase and uses the correct path
                    string navigationRoute = route.ToLower() switch
                    {
                        "fertilizers" => "gardencare/fertilizers",
                        "pestcontrol" => "gardencare/pest-control",
                        "soilmulch" => "gardencare/soil-and-mulch",
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

            GardenCares = new List<GardenCare>();
        }
    }
}
