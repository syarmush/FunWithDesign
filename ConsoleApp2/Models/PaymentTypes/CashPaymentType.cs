namespace ConsoleApp2.Models.PaymentTypes
{
    internal class CashPaymentType : PaymentType<CashPayment>
    {
        private CashPaymentType() { }

        public static readonly CashPaymentType Instance = new CashPaymentType();

        public override string Name => "Cash";
        public override Type Type => typeof(CashPayment);
        public override IEnumerable<Predicate<CashPayment>> Validations => new Predicate<CashPayment>[] { p => p.Denominations == "5,2,1" };
    }
}