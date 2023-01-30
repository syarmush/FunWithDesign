namespace ConsoleApp2.Models.PaymentTypes
{
    public abstract class Payment
    {
        protected Payment(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; set; }
    }
}
