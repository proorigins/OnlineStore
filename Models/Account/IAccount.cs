using System.Collections.Generic;
using Enums;
using Models.PaymentMethod;
using Models.Shipping;

namespace Models.Account
{
    public interface IAccount
    {
        string Name { get; set; }
        Currency Currency { get; set; }
        bool IsLoggedIn { get; set; }
        List<ICard> PaymentMethods { get; set; }
    }
}