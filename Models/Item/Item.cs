using Enums;

namespace Models.Item
{
    public class Item : IItem
    {
        public Item(int id, string name, ItemCategory category, double price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public double Price { get; set; }
    }
}