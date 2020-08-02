namespace Models.PaymentMethod
{
    public class PayPal : Card, IDigitalPaymentMethod
    {
        public string Username { get; set; }
        private bool IsLoggedIn { get; set; }
        
        public void Login()
        {
            IsLoggedIn = true;
        }
    }
}