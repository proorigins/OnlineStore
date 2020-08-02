namespace Models.PaymentMethod
{
    public interface ITransaction
    {
        bool Withdraw(double amount);
        bool Charge(double amount);
        bool CheckAccount();
        bool CheckAccount(double amount);
    }
}