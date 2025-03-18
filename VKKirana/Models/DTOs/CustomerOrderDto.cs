namespace VKKirana.Models.DTOs
{
    public class CustomerOrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}