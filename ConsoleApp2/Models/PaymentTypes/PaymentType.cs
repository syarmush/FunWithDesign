namespace ConsoleApp2.Models.PaymentTypes
{
    public abstract class PaymentType
    {
        public abstract string Name { get; }
        public abstract Type Type { get; }
    }

    public abstract class PaymentType<TPayment> : PaymentType where TPayment : Payment
    {
        public override Type Type => typeof(TPayment);
        public abstract IEnumerable<Predicate<TPayment>> Validations { get; }
    }
}
