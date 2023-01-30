namespace ConsoleApp2.Models
{
    public class PaymentResponse
    {
        public static PaymentResponse SuccessResponse = new PaymentResponse(true);
        public static PaymentResponse FailResponse = new PaymentResponse(false);

        private PaymentResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; internal set; }
    }
}