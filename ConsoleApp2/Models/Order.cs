namespace ConsoleApp2.Models
{
    public class Order
    {
        public Order(int orderAmount)
        {
            Total = orderAmount;
        }

        public int Total { get; }
    }
}