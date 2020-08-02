using System.Linq;
using Models;
using Models.Item;
using Models.Shipping;

namespace Extensions
{
    public static class CartExtensions
    {
        public static void AddItem(this ICart cart, IItem item, int quantity)
        {
            if(cart.Items.HasItemGroup(item.Id))
            {
                cart.Items.GetItemGroup(item.Id).Quantity += quantity;
            }
            else
            {
                cart.Items.CreateItemGroup(item, quantity);
            }
        }
        
        public static void RemoveItem(this ICart cart, IItem item, int quantity)
        {
            if(cart.Items.HasItemGroup(item.Id))
            {
                cart.Items.GetItemGroup(item.Id).Quantity -= quantity;
            }
        }

        public static bool IsEmpty(this ICart cart)
        {
            return !cart.Items.Any();
        }
        
        public static void Clear(this ICart cart)
        {
            cart.Items.Clear();
        }
        
        public static bool HasPaymentMethod(this ICart cart)
        {
            return cart.PaymentMethod != null;
        }
    }
}