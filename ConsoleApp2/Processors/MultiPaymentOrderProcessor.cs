using ConsoleApp2;
using ConsoleApp2.Attributes;
using ConsoleApp2.Models;
using ConsoleApp2.Models.PaymentTypes;
using ConsoleApp2.Processors;
using System.Reflection;

internal class MultiPaymentOrderProcessor : IOrderProcessor
{
    private IDictionary<PaymentType, IPaymentProcessor> _acceptedPaymentTypes;
    private PaymentType[] _indexedPaymentTypes;

    public MultiPaymentOrderProcessor(IDictionary<PaymentType, IPaymentProcessor> acceptedPaymentTypes)
    {
        _acceptedPaymentTypes = acceptedPaymentTypes;
        _indexedPaymentTypes = acceptedPaymentTypes.Keys.ToArray();
    }

    public OrderResponse ProcessOrder(Order order)
    {
        DisplayPaymentOptions();
        PaymentType specifiedPaymentOption = ReadAndProcessSpecifiedPaymentOption();

        //Would use DI in real system
        IPaymentProcessor paymentProcessor = _acceptedPaymentTypes[specifiedPaymentOption];
        PaymentResponse paymentResponse =  paymentProcessor.ProcessPayment(order);


        if (!paymentResponse.Success)
        {
            return OrderResponse.FailResponse;
        }

        return OrderResponse.SuccessResponse;
    }

    private PaymentType ReadAndProcessSpecifiedPaymentOption()
    {
        string? rawResponse  = Console.ReadLine();

        int selectedValue = int.Parse(rawResponse);

        //assumes all is perfect. Not focusing on this logic (and error checking) for this exercise.
        return _indexedPaymentTypes.ElementAt(selectedValue);
    }

    private void DisplayPaymentOptions()
    {
        Console.WriteLine("Accepted Payment Methods: (Specify the number of the method to use.)");

        foreach (var (paymentType, index) in _indexedPaymentTypes.Select((paymentType, index) => (paymentType, index)))
        {
            Console.WriteLine($"{index}: {paymentType.Name}");
        }
    }
}