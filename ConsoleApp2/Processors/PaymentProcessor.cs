using ConsoleApp2.Attributes;
using ConsoleApp2.Models;
using ConsoleApp2.Models.PaymentTypes;
using ConsoleApp2.Processors;
using System.Reflection;

internal class PaymentProcessor<TPayment> : IPaymentProcessor where TPayment : Payment
{
    public PaymentProcessor(PaymentType<TPayment> paymentType)
    {
        PaymentType = paymentType ?? throw new ArgumentNullException(nameof(paymentType));
    }

    protected PaymentType<TPayment> PaymentType { get; }

    public PaymentResponse ProcessPayment(Order order)
    {
        TPayment payment = InstantiateNewPaymentForOrderWithPaymentOption(order);

        DisplayAndGetPaymentDetails(payment);

        if(!PaymentType.Validations.All(p => p(payment)))
        {
            return PaymentResponse.FailResponse;
        }

        return PaymentResponse.SuccessResponse;
    }

    private TPayment InstantiateNewPaymentForOrderWithPaymentOption(Order order)
    {
        Type paymentType = PaymentType.Type;

        //assumes all is perfect. Not focusing on error checking for this exercise.
        return (TPayment)Activator.CreateInstance(paymentType, new object[] { order.Total})!;
    }

    private void DisplayAndGetPaymentDetails(TPayment payment)
    {
        IEnumerable<PropertyInfo> paymntUserInfoFields = ExtractPaymentUserInfoFields(payment);

        foreach (PropertyInfo paymentUserField in paymntUserInfoFields)
        {
            PaymentDisplayFieldAttribute displayFieldAttribute = (PaymentDisplayFieldAttribute)Attribute.GetCustomAttribute(paymentUserField, typeof(PaymentDisplayFieldAttribute))!;

            Console.WriteLine(displayFieldAttribute.DisplayFieldName);
            string value = Console.ReadLine()!;

            //assuming always expected value. In proper system would have a response processor that would process the user response, check for erros and parse as necessary.
            paymentUserField.SetValue(payment, value);
        }
    }

    private IEnumerable<PropertyInfo> ExtractPaymentUserInfoFields(Payment payment)
    {
        return payment.GetType().GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(PaymentDisplayFieldAttribute)));
    }
}