using System;
using AuthApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthApp;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u=> u.Username)
            .IsUnique();
    }
}
