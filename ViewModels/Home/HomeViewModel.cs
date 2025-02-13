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
                switch (route.ToLower())
                {
                    case "plants":
                        await Shell.Current.GoToAsync("//Plants");
                        break;
                    case "tools":
                        await Shell.Current.GoToAsync("//Tools");
                        break;
                    case "gardencare":
                        await Shell.Current.GoToAsync("//GardenCare");
                        break;
                    case "cart":
                        await Shell.Current.GoToAsync("cart");
                        break;
                    default:
                        // Optional: handle unexpected routes
                        break;
                }
            });
        }
    }
}
