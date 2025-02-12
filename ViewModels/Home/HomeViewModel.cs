using System.Windows.Input;

namespace GardenApp.ViewModels
{
    public class HomeViewModel
    {
        public ICommand NavigateCommand { get; }

        public HomeViewModel()
        {
            NavigateCommand = new Command<string>(async (route) =>
            {
                await Shell.Current.GoToAsync($"//{route}");
            });
        }
    }
}