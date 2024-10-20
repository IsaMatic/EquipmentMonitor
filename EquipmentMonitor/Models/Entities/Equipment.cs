using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitor.Models.Entities;

public class Equipment
{
    public int Id { get; set; }
    [MaxLength(20)] 
    public string Name { get; set; } = null!;            
    public EquipmentState State { get; set; }
    [MaxLength(50)]
    public string Location { get; set; } = null!;      
    public DateTime LastUpdated { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public enum EquipmentState
{
    Red,    // Standing still
    Yellow, // Starting up or winding down
    Green   // Producing normally
}