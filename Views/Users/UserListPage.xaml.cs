using Microsoft.Maui.Controls;

namespace GardenApp.Views
{
    public partial class UserListPage:ContentPage
    {
        public UserListPage()  // Removing the ViewModel dependency initially
        {
            InitializeComponent();
            // add the ViewModel binding later when we implement user functionality
        }
    }
}