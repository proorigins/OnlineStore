using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Item;

namespace Extensions
{
    public static class ItemGroupExtensions
    {
        public static IItemGroup GetItemGroup(this List<IItemGroup> itemGroup, int id)
        {
            return itemGroup.FirstOrDefault(t => t.Item.Id == id);
        }
        
        public static bool HasItemGroup(this List<IItemGroup> itemGroup, int id)
        {
            return itemGroup.Any(t => t.Item.Id == id);
        }
        
        public static void CreateItemGroup(this List<IItemGroup> itemGroup, IItem item, int quantity)
        {
            itemGroup.Add(new ItemGroup { Item = item, Quantity = quantity});
        }
        
        public static IItem GetItem(this List<IItemGroup> itemGroup, int id)
        {
            return itemGroup.GetItemGroup(id).Item;
        }
        
        public static double GetItemTotalPrice(this IItemGroup itemGroup)
        {
            return itemGroup.Item.Price * itemGroup.Quantity;
        }
        
        public static double GetTotalPrice(this List<IItemGroup> itemGroup)
        {
            return itemGroup.Select(i => i.GetItemTotalPrice()).ToList().Sum(); 
        }
    }
}