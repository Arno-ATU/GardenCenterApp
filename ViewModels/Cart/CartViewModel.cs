using System.Collections.ObjectModel;
using GardenApp.Services;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class CartViewModel:BaseViewModel
    {
        private readonly CartService _cartService;
        private readonly AuthService _authService;

        public ObservableCollection<CartItem> CartItems => _cartService.Items;

        public decimal Total => _cartService.GetTotal();

        public bool IsCartEmpty => _cartService.Items.Count == 0;

        public Command<string> RemoveFromCartCommand { get; }
        public Command CheckoutCommand { get; }
        public Command ContinueShoppingCommand { get; }
        public Command LogoutCommand { get; }

        public CartViewModel(CartService cartService, AuthService authService)
        {
            _cartService = cartService;
            _authService = authService;
            RemoveFromCartCommand = new Command<string>(OnRemoveFromCart);
            CheckoutCommand = new Command(OnCheckout);
            ContinueShoppingCommand = new Command(OnContinueShopping);
            LogoutCommand = new Command(OnLogout);

            _cartService.CartChanged += (_, _) =>
            {
                OnPropertyChanged(nameof(Total));
                OnPropertyChanged(nameof(IsCartEmpty));
            };
        }

        private void OnRemoveFromCart(string productId)
        {
            _cartService.RemoveFromCart(productId);
        }

        private async void OnCheckout()
        {
            if (!_authService.IsLoggedIn)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Login Required",
                    "Please log in to proceed to checkout.",
                    "OK"
                );
                await Shell.Current.GoToAsync("login");
                return;
            }

            await Shell.Current.GoToAsync("checkout");
        }

        private async void OnContinueShopping()
        {
            await Shell.Current.GoToAsync("//Home");
        }

        private async void OnLogout()
        {
            _authService.Logout();
            await Shell.Current.GoToAsync("//login");
        }
    }
}
