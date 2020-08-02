using System.Collections.Generic;
using Enums;
using Models.Item;
using Models.PaymentMethod;

namespace Models.Shipping
{
    public interface ICart
    {
        List<IItemGroup> Items { get; }
        ICard PaymentMethod { get; }
        void AddPaymentMethod(ICard card);
    }
}