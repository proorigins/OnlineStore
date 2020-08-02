using Enums;

namespace Models.PaymentMethod
{
    public class Card : ICard
    {
        
        public string Number { get; set; }
        public string Password { get; set; }
        public string Provider { get; set; }
        public double Amount { get; set; }
        
        public Currency Currency { get; set; }

        public  bool Withdraw(double amount)
        {
            if (!CheckAccount() || !CheckAccount(amount))
            {
                return false;
            }
            Amount -= amount;
            return true;

        }

        public virtual bool Charge(double amount)
        {
            Amount += amount;
            return true;
        }

        public bool CheckAccount(double amount)
        {
            return !(Amount < amount);
        }

        public bool CheckAccount()
        {
            return !(Amount <=0);
        }
    }
}