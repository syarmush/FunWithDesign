namespace ConsoleApp2.Models.PaymentTypes
{
    internal class CreditCardPaymentType : PaymentType<CreditCardPayment>
    {
        private CreditCardPaymentType() { }

        public static readonly CreditCardPaymentType Instance = new CreditCardPaymentType();

        public override string Name => "Credit Card";
        public override IEnumerable<Predicate<CreditCardPayment>> Validations => new Predicate<CreditCardPayment>[] { p =>  !string.IsNullOrWhiteSpace(p.CreditCardNumber) && Int64.TryParse(p.CreditCardNumber, out long _) };
    }
}