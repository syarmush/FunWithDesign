namespace ConsoleApp2.Models
{
    public class OrderResponse
    {
        public static OrderResponse SuccessResponse = new OrderResponse(true);
        public static OrderResponse FailResponse = new OrderResponse(false);

        private OrderResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; internal set; }
    }
}