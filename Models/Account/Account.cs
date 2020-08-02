using System.Collections.Generic;
using Enums;
using Models.PaymentMethod;
using Models.Shipping;

namespace Models.Account
{
    public class Account : IAccount
    {
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public bool IsLoggedIn { get; set; }
        public List<ICard> PaymentMethods { get; set; }
    }
}