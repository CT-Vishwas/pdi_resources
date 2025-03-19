using System;
using Microsoft.EntityFrameworkCore;

namespace paymentApp.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Payment> Payments { get; set; }

}
