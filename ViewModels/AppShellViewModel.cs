using System.ComponentModel;
using System.Runtime.CompilerServices;
using GardenApp.Services;

namespace GardenApp
{
    public class AppShellViewModel:INotifyPropertyChanged
    {
        private readonly AuthService _authService;
        private bool _isUserLoggedIn;
        private string _userCartTitle;

        public AppShellViewModel(AuthService authService)
        {
            _authService = authService;
            _authService.AuthenticationChanged += OnAuthenticationChanged;
            UpdateUserState();
        }

        public bool IsUserLoggedIn
        {
            get => _isUserLoggedIn;
            set
            {
                if (_isUserLoggedIn != value)
                {
                    _isUserLoggedIn = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserCartTitle
        {
            get => _userCartTitle;
            set
            {
                if (_userCartTitle != value)
                {
                    _userCartTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnAuthenticationChanged(object sender, EventArgs e)
        {
            UpdateUserState();
        }

        private void UpdateUserState()
        {
            IsUserLoggedIn = _authService.IsLoggedIn;
            UserCartTitle = _authService.IsLoggedIn ? $"{_authService.CurrentUser.Username}'s Cart" : "Cart";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
