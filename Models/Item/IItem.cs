using Enums;

namespace Models.Item
{
    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        ItemCategory Category { get; set; }
        double Price { get; set; }
    }
}