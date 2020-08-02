using Enums;
using Extensions;
using Models;
using Models.Store;

namespace Services
{
    public class StoreLocalizerService : IStoreLocalizerService
    {
        public IStore LocalizeStore(IStore store, Currency currency)
        {
            foreach (var itemGroup in store.Items)
            {
                itemGroup.Item.Price = itemGroup.Item.GetPrice(store.Currency, currency);
            }

            store.Currency = currency;
            return store;
        }
    }
}