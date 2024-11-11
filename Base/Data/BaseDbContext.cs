using FarmControl.Base.Extensions;
using FarmControl.Features.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Base.Data;

public  class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{ 
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Field> Fields { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}
