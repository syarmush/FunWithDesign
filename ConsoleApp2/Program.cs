using ConsoleApp2;
using ConsoleApp2.Models;
using ConsoleApp2.Models.PaymentTypes;
using ConsoleApp2.Processors;

class ProgramBad
{
    static void Main()
    {
        IDictionary<PaymentType, IPaymentProcessor> acceptedPaymentType = new Dictionary<PaymentType, IPaymentProcessor> {
            { CashPaymentType.Instance, new PaymentProcessor<CashPayment>(CashPaymentType.Instance)}, 
            { CreditCardPaymentType.Instance, new PaymentProcessor<CreditCardPayment>(CreditCardPaymentType.Instance)}
        };

        Order order = new Order(50);//trivial order value

        IOrderProcessor orderProcessor = new MultiPaymentOrderProcessor(acceptedPaymentType);

        OrderResponse response = orderProcessor.ProcessOrder(order);

        Console.WriteLine($"Order was {(response.Success ? "" : "not ")}successful");
    }
}