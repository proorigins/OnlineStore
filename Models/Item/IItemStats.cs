namespace Models.Item
{
    public interface IItemGroup
    {
        IItem Item { get; set; }
        int Quantity { get; set; }
    }
}