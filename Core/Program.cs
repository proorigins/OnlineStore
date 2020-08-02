using System.Collections.Generic;
using System.Linq;
using Enums;
using Extensions;
using Models;
using Models.Account;
using Models.Item;
using Models.PaymentMethod;
using Models.Shipping;
using Models.Store;
using Services;
using Services.Logging;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccount myAccount = new Account() {Currency = Currency.ILS, Name = "Basel", PaymentMethods = new List<ICard>()
            {
                new MasterCard {Number = "20506070", Password = "4321", Provider = "PayPal", Amount = 300, Currency = Currency.USD}
            }};
            
            IStore store = new Store();
            ICart myCart = new Cart();
            var myPaymentMethod = myAccount.PaymentMethods.Single(); 
            
            ILoggingService loggingService = new LoggingService();
            ICartService cartService = new CartService();
            IStoreLocalizerService storeLocalizerService = new StoreLocalizerService();

            myAccount.IsLoggedIn = true;
            
            //fill My Store
            store.AddItem(new Item(id: 1, name: "MacBook Pro", category: ItemCategory.Electronics, price: 100), 10);
            store.AddItem(new Item(id: 1, name: "MacBook Pro", category: ItemCategory.Electronics, price: 100), 5);
            store.AddItem(new Item(id: 2, name: "T-Shirt", category: ItemCategory.Clothes, price: 7), 5);
            
            //localize store
            store = storeLocalizerService.LocalizeStore(store, myAccount.Currency);
            
            //init my cart 
            myCart.AddPaymentMethod(myPaymentMethod);
            
            //fill my cart
            cartService.AddToCart(store, myCart, 1, 3);
            cartService.AddToCart(store, myCart, 2, 8);
            
            //Process Payment
            loggingService.Log($"My Balance: {myPaymentMethod.Amount}");
            cartService.ProcessPaymentFor(store, myCart, myAccount);
            loggingService.Log($"My Balance: {myPaymentMethod.Amount}");
        }
    }
}