using EquipmentMonitor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitor.Data;

public class EquipmentMonitorDbContext : DbContext
{
    public EquipmentMonitorDbContext(DbContextOptions<EquipmentMonitorDbContext> options) : base(options)
    { }
    
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Equipment>()
            .HasMany(o => o.Orders)
            .WithOne(o => o.Equipment)
            .IsRequired(false);
        
        modelBuilder.Entity<Equipment>().HasData(
            new Equipment { Id = 1, Name = "Equipment1", State = EquipmentState.Green, LastUpdated = DateTime.UtcNow, Location = "Location1" },
            new Equipment { Id = 2, Name = "Equipment2", State = EquipmentState.Red, LastUpdated = DateTime.UtcNow, Location = "Location2" },
            new Equipment { Id = 3, Name = "Equipment3", State = EquipmentState.Yellow, LastUpdated = DateTime.UtcNow, Location = "Location1" }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, EquipmentId = 1, Description = "No Description", Quantity = 5, Status = OrderStatus.Created, ProductId = 1},
            new Order { Id = 2, EquipmentId = 2, Description = "No Description", Quantity = 3, Status = OrderStatus.Completed, ProductId = 2},
            new Order { Id = 3, EquipmentId = 3, Description = "No Description", Quantity = 2, Status = OrderStatus.InProgress, ProductId = 1},
            new Order { Id = 4, EquipmentId = 1, Description = "No Description", Quantity = 1, Status = OrderStatus.InProgress, ProductId = 2},
            new Order { Id = 5, EquipmentId = 2, Description = "No Description",  Quantity = 4, Status = OrderStatus.Created, ProductId = 1}
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product1" },
            new Product { Id = 2, Name = "Product2" }
        );
    }
}