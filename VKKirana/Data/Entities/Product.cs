using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace VKKirana.Entities;

[Table("Products")]
[Comment("A Product Table for Ecommerce Website")]
public class Product
{
    [Column("product_id")]
    [Key]
    public Guid Id { get; set; }
    [Column("product_name")]
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Precision(6, 2)]
    public double Price { get; set; }
    public int Quantity { get; set; }

    public string? Description { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<Category>? Categories { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow ;
    
    public List<CustomerOrder> CustomerOrders { get; } = [];
}