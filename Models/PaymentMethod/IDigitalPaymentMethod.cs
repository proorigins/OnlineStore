namespace Models.PaymentMethod
{
    public interface IDigitalPaymentMethod : ICard
    {
        string Username { get; set; }

        void Login();
    }
}