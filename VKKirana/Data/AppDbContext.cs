using System;
using Microsoft.EntityFrameworkCore;
using VKKirana.Entities;

namespace VKKirana.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
