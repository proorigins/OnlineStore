using System;
using System.Linq;
using Extensions;
using Models;
using Models.Account;
using Models.Shipping;
using Models.Store;
using Services.Logging;

namespace Services
{
    public class CartService : ICartService
    {
        public ILoggingService LoggingService { get; set; }

        public CartService()
        {
            LoggingService = new LoggingService();
        }

        public bool AddToCart(IStore store, ICart cart, int id, int quantity)
        {
            if (!store.CheckItemAvailability(id, quantity))
            {
                return false;
            }
            
            var item = store.Items.GetItem(id);
            store.RemoveItem(item, quantity);
            cart.AddItem(item, quantity);

            return true;
        }

        public bool RemoveFromCart(IStore store, ICart cart, int id, int quantity)
        {
            var item = store.Items.GetItem(id);
            cart.RemoveItem(item, quantity);
            store.AddItem(item, quantity);
            return true;
        }

        public bool ClearCart(IStore store, ICart cart)
        {
            var cardItems = cart.Items;
            foreach (var item in cardItems)
            {
                store.AddItem(item.Item, item.Quantity);
            }
            cart.Clear();
            return true;
        }

        public bool ProcessPaymentFor(IStore store, ICart cart, IAccount account)
        {
            LoggingService.Log("______________________");
            LoggingService.Log("Processing Payment ...");
            if (!account.IsLoggedIn)
            {
                throw new Exception("Unauthorized");
            }
            
            if (cart.IsEmpty())
            {
                throw new Exception("cart is empty");
            }
            
            if (!cart.HasPaymentMethod())
            {
                throw new Exception("Payment method is not set");
            }

            var oldPrice = cart.Items.GetTotalPrice();
            var price = Models.CurrencyUtils.CurrencyUtils.Convert(oldPrice, store.Currency, cart.PaymentMethod.Currency);
            LoggingService.Log($"Paying with {cart.PaymentMethod.GetType().ToString().Split(".").LastOrDefault()}");
            if (cart.PaymentMethod.Withdraw(price))
            {
                LoggingService.Log("Done.");
                LoggingService.Log("______________________");
                cart.Clear();
                return true;
            }
            LoggingService.Log("Failed: Not Enough Amount!");
            LoggingService.Log("______________________");
            return false;
        }
    }
}