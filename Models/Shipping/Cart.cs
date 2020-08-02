using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Models.Item;
using Models.PaymentMethod;

namespace Models.Shipping
{
    public class Cart : ICart
    {
        public List<IItemGroup> Items { get; private set; } =  new List<IItemGroup>();
        public ICard PaymentMethod { get; private set;  }

        public void AddPaymentMethod(ICard card)
        {
            PaymentMethod = card;
        }
    }
}