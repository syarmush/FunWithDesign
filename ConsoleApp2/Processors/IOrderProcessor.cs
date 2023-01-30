using ConsoleApp2.Models;

namespace ConsoleApp2.Processors
{
    internal interface IOrderProcessor
    {
        OrderResponse ProcessOrder(Order order);
    }
}
