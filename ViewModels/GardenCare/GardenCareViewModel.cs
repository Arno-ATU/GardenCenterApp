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
                await Shell.Current.GoToAsync($"//gardencare/{route.ToLower()}");
            });

            GardenCares = new List<GardenCare>();
        }
    }
}
