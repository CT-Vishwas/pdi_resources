namespace VKKirana.Models.Requests
{
    public class UpdateCustomerOrderRequest
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UpdateCustomerOrderRequest()
        {
            Items = new List<OrderItem>();
        }
    }
}