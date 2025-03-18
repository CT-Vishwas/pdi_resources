using System;
using System.ComponentModel.DataAnnotations;

namespace VKKirana.Data.Entities;

public class OrderStatus
{
    public Guid Id { get; set; }
    [Required]    
    public required string Status { get; set; }
}
