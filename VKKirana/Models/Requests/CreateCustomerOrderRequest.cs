namespace VKKirana.Models.Requests
{
    public class CreateCustomerOrderRequest
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ContactNumber { get; set; }

        public CreateCustomerOrderRequest()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}