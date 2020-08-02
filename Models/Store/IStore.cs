using System.Collections.Generic;
using Enums;
using Models.Item;

namespace Models.Store
{
    public interface IStore
    {
        List<IItemGroup> Items { get; }
        Currency Currency { get; set; }
    }
}