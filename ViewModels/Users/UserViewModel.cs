using GardenApp.Models;

namespace GardenApp.ViewModels

{
    public class UserViewModel
    {
        public List<User> Users { get; set; }

        public UserViewModel()
        {
            Users = new List<User>();
        }
    }
}
