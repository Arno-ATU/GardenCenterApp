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
                await Shell.Current.GoToAsync($"//tools/{route.ToLower()}");
            });
        }
    }
}

