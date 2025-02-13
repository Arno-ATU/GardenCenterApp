using GardenApp.Models;
using System.Collections.ObjectModel;

namespace GardenApp.Services
{
    public class CartService
    {
        public ObservableCollection<CartItem> Items { get; private set; } = new ObservableCollection<CartItem>();

        public event EventHandler CartChanged;

        public void AddToCart(Product product, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveFromCart(string productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                Items.Remove(item);
                CartChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ClearCart()
        {
            Items.Clear();
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public decimal GetTotal()
        {
            return Items.Sum(item => item.Product.Price * item.Quantity);
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
