using System.Collections.ObjectModel;
using GardenApp.Services;
using GardenApp.Models;

namespace GardenApp.ViewModels
{
    public class CartViewModel:BaseViewModel
    {
        private readonly CartService _cartService;

        public ObservableCollection<CartItem> CartItems => _cartService.Items;

        public decimal Total => _cartService.GetTotal();

        public Command<string> RemoveFromCartCommand { get; }

        public CartViewModel(CartService cartService)
        {
            _cartService = cartService;
            RemoveFromCartCommand = new Command<string>(OnRemoveFromCart);
            _cartService.CartChanged += (_, _) => OnPropertyChanged(nameof(Total));
        }

        private void OnRemoveFromCart(string productId)
        {
            _cartService.RemoveFromCart(productId);
        }
    }
}
