using System.ComponentModel.DataAnnotations;

namespace VKKirana.Entities;

public class CustomerOrder
{
    [Key]
    public required Guid OrderId { get; set; }

    public DateOnly OrderDate { get; set; }


    public List<Product> OrderItems { get; set; } = [];

    public decimal TotalAmount { get; set; }

    public OrderStatus? OrderStatus { get; set; }

}
