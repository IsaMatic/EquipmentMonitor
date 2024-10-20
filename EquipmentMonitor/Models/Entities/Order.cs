using System.ComponentModel.DataAnnotations;

namespace EquipmentMonitor.Models.Entities;

public class Order
{
    public int Id { get; set; }   
    [MaxLength(100)]
    public string Description { get; set; } = null!; 
    public int Quantity { get; set; }
    public int? EquipmentId { get; set; }
    public Equipment? Equipment { get; set; }
    public int ProductId { get; set; } 
    public Product Product { get; set; } = null!;
    
    public OrderStatus Status { get; set; }  
}

public enum OrderStatus
{
    Created,
    InProgress,
    Completed
}