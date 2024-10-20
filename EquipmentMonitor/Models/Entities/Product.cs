using System.ComponentModel.DataAnnotations;

namespace EquipmentMonitor.Models.Entities;

public class Product
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string Name { get; set; } = null!;   
    public ICollection<Order> Orders { get; set; } = new List<Order>(); 
}