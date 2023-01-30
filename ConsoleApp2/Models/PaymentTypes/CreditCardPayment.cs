using ConsoleApp2.Attributes;

namespace ConsoleApp2.Models.PaymentTypes
{
    public class CreditCardPayment : Payment
    {
        [PaymentDisplayField("Credit Card Number")]
        public string? CreditCardNumber { get; set; }

        public CreditCardPayment(int amount) : base(amount)
        {
        }
    }
}
