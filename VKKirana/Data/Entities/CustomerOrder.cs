using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using VKKirana.Entities;

namespace VKKirana.Data.Entities;

public class CustomerOrder
{

    public Guid OrderId { get; set; }

    public DateOnly OrderDate { get; set; }


    public List<Product> OrderItems { get; set; } = [];

    public decimal TotalAmount { get; set; }

    public OrderStatus? OrderStatus { get; set; }

}
