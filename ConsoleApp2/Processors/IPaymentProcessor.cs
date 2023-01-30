using ConsoleApp2.Models;
using ConsoleApp2.Models.PaymentTypes;

namespace ConsoleApp2.Processors
{
    internal interface IPaymentProcessor
    {
        PaymentResponse ProcessPayment(Order order);
    }
}