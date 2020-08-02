using Models;
using Models.Item;
using Models.Store;

namespace Extensions
{
    public static class StoreExtensions
    {
        public static void AddItem(this IStore store, IItem item, int quantity)
        {
            if (store.Items.HasItemGroup(item.Id))
            {
                store.Items.GetItemGroup(item.Id).Quantity += quantity;
            }
            else
            {
                store.Items.CreateItemGroup(item, quantity);
            }
        }

        public static void RemoveItem(this IStore store, IItem item, int quantity)
        {
            if (store.Items.HasItemGroup(item.Id))
            {
                store.Items.GetItemGroup(item.Id).Quantity -= quantity;
            }
        }

        public static bool CheckItemAvailability(this IStore store, int id, int quantity)
        {
            var item = store.Items.GetItemGroup(id);
            return item != null && item.Quantity >= quantity;
        }
    }
}