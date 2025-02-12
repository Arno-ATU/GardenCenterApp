using System;
using GardenApp.Models;

namespace GardenApp.Services
{
    public class AuthService
    {
        public User CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;

        public event EventHandler AuthenticationChanged;

        public void Login(User user)
        {
            CurrentUser = user;
            AuthenticationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Logout()
        {
            CurrentUser = null;
            AuthenticationChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
