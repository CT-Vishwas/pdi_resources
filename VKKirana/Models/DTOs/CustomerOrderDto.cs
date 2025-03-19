namespace VKKirana.Models.DTOs
{
    public class CustomerOrderDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = [];
        public decimal TotalAmount { get; set; }
    }
}