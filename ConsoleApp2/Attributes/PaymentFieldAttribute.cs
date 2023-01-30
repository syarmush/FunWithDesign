namespace ConsoleApp2.Attributes
{
    internal class PaymentDisplayFieldAttribute : Attribute
    {
        public PaymentDisplayFieldAttribute(string displayFieldName)
        {
            DisplayFieldName = displayFieldName ?? throw new ArgumentNullException(nameof(displayFieldName));
        }

        public string DisplayFieldName { get; }
    }
}