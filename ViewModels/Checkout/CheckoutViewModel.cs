using System.Collections.ObjectModel;
using System.Windows.Input;
using GardenApp.Models;
using GardenApp.Services;

namespace GardenApp.ViewModels
{
    public class CheckoutViewModel:BaseViewModel
    {
        private readonly CartService _cartService;
        private readonly AuthService _authService;

        public ObservableCollection<CartItem> CartItems => _cartService.Items;
        public decimal Total => _cartService.GetTotal();

        public string HeaderText { get; }
        public string CheckoutButtonText { get; }

        public ICommand CheckoutCommand { get; }

        public CheckoutViewModel(CartService cartService, AuthService authService)
        {
            _cartService = cartService;
            _authService = authService;

            // Set header and button text based on user type
            if (_authService.CurrentUser.IsCorporate)
            {
                HeaderText = "Corporate User Checkout";
                CheckoutButtonText = "Make Purchase";
            }
            else
            {
                HeaderText = "Checkout";
                CheckoutButtonText = "Pay Now";
            }

            CheckoutCommand = new Command(OnCheckout);
        }

        private async void OnCheckout()
        {
            if (_authService.CurrentUser.IsCorporate)
            {
                // Corporate user checkout
                await ShowCorporateCheckoutAlert();
            }
            else
            {
                // Standard user checkout
                await ShowStandardCheckoutAlert();
            }
        }

        private async Task ShowCorporateCheckoutAlert()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Corporate Purchase",
                $"Successfully ordered {CartItems.Count} items for ${Total:F2}. " +
                "Payment will be deducted at the end of the month.",
                "OK"
            );

            // Clear the cart after successful checkout
            _cartService.ClearCart();

            // Navigate back to home page
            await Shell.Current.GoToAsync("//main");
        }

        private async Task ShowStandardCheckoutAlert()
        {
            await Application.Current.MainPage.DisplayAlert(
                "Payment Successful",
                $"Purchased {CartItems.Count} items for ${Total:F2}",
                "OK"
            );

            // Clear the cart after successful checkout
            _cartService.ClearCart();

            //  back to home page
            await Shell.Current.GoToAsync("//main");
        }
    }
}
