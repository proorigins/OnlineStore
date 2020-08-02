using Models;
using Models.Account;
using Models.Shipping;
using Models.Store;

namespace Services
{
    public interface ICartService
    {
        bool AddToCart(IStore store, ICart cart, int id, int quantity);
        bool RemoveFromCart(IStore store, ICart cart, int id, int quantity);

        bool ClearCart(IStore store, ICart cart);

        bool ProcessPaymentFor(IStore store, ICart cart, IAccount account);
    }
}