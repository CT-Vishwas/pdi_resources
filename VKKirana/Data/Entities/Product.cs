using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VKKirana.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<Category>? Categories { get; set; }
}