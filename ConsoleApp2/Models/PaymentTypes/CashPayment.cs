using ConsoleApp2.Attributes;

namespace ConsoleApp2.Models.PaymentTypes
{
    public class CashPayment : Payment
    {
        [PaymentDisplayField("Comma sperated Denominations")]
        public string? Denominations { get; set; }

        public CashPayment(int amount) : base(amount)
        {
        }
    }
}
