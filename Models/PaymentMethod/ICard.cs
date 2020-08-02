using Enums;

namespace Models.PaymentMethod
{
    public interface ICard : ITransaction
    {
        string Number { get; set; }
        string Password { get; set; }
        string Provider { get; set; }
        double Amount { get; set; }
        Currency Currency { get; set; }
    }
}