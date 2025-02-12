using GardenApp.Services;
using GardenApp.Models;
using System.Windows.Input;

namespace GardenApp.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private bool _isCorporate;
        public bool IsCorporate
        {
            get => _isCorporate;
            set => SetProperty(ref _isCorporate, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand CreateAccountCommand { get; }

        public LoginViewModel(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
            LoginCommand = new Command(OnLogin);
            CreateAccountCommand = new Command(OnCreateAccount);
        }

        private async void OnLogin()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(PhoneNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter both username and phone number", "OK");
                return;
            }

            if (_userService.AuthenticateUser(Username, PhoneNumber))
            {
                var user = _userService.GetUser(Username);
                _authService.Login(user);
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or phone number", "OK");
            }
        }

        private async void OnCreateAccount()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(PhoneNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter both username and phone number", "OK");
                return;
            }

            if (_userService.CreateUser(Username, PhoneNumber, IsCorporate))
            {
                var user = _userService.GetUser(Username);
                _authService.Login(user);
                await Application.Current.MainPage.DisplayAlert("Success", "Account created successfully", "OK");
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Username already exists", "OK");
            }
        }
    }
}
