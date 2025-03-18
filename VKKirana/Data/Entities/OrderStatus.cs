using System;
using System.ComponentModel.DataAnnotations;

namespace VKKirana.Entities;

public class OrderStatus
{
    public Guid Id { get; set; }
    [Required]    
    public required string Status { get; set; }
}
