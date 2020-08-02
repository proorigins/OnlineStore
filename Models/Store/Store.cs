using System.Collections.Generic;
using Enums;
using Models.Item;

namespace Models.Store
{
    public class Store : IStore
    {
        public List<IItemGroup> Items { get; private set; }
        public Currency Currency { get; set;  }

        public Store()
        {
            Items = new List<IItemGroup>();
            Currency = Currency.USD;
        }
    }
}