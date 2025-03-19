

using VKKirana.Entities;
namespace VKKirana.Models.DTOs;
public class ProductDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }

    public List<Category>? Categories { get; set; }
}