namespace Models.Item
{
    public class ItemGroup : IItemGroup
    {
        public int Quantity { get; set; }
        public IItem Item { get; set; }
    }
}