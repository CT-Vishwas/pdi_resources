using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VKKirana.Data.Entities;
using VKKirana.Entities;


namespace VKKirana.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<CustomerOrder> CustomerOrders { get; set; }

    public DbSet<PaymentDetails> PaymentDetails { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
            .Property(c => c.Categories)
            .HasConversion(
                new ValueConverter<List<Category>, string>(
                    value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
                    static value => JsonSerializer.Deserialize<List<Category>>(value, (JsonSerializerOptions?)null) ?? new List<Category>()
                )
            )
            .Metadata.SetValueComparer(
                new ValueComparer<List<Category>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                )
            );

        modelBuilder.Entity<CustomerOrder>()
            .HasMany(e => e.OrderItems)
            .WithMany(e => e.CustomerOrders);

        // Seed Data for orderStatus
        var orderStatus = new List<OrderStatus>
            {
                new OrderStatus { Id = Guid.Parse("cb1a5dc1-4b47-48d6-866c-bcb123684ca1") , Status = "Pending" },
                new OrderStatus { Id = Guid.Parse("7e74aeb4-a430-43e5-a5d8-4e2b00a0979c"), Status = "Processing" },
                new OrderStatus { Id = Guid.Parse("c54496d8-8d2c-4ba3-8bfc-6afcbe8a3dcf"), Status = "Delivered" },
                new OrderStatus { Id = Guid.Parse("9cde19d5-eca6-4c86-8bce-fd4ae82ec5f2"), Status = "Cancelled" }
            };
        
        modelBuilder.Entity<OrderStatus>().HasData(orderStatus);
    }

}
