using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VKKirana.Entities;

namespace VKKirana.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Product>()
            .Property(c => c.Categories)
            .HasConversion(
                new ValueConverter<List<Category>, string>(
                    value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
                    value => JsonSerializer.Deserialize<List<Category>>(value, (JsonSerializerOptions?)null) ?? new List<Category>()
                )
            );

}
