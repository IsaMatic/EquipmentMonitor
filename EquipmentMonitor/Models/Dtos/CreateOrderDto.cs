using EquipmentMonitor.Models.Entities;

namespace EquipmentMonitor.Models.Dtos;

public record CreateOrderDto
{
    public string Description { get; set; } = null!; 
    public int Quantity { get; set; }
    public int? EquipmentId { get; set; }       
    public OrderStatus Status { get; set; }
    public int ProductId { get; set; }
    
   public static implicit operator Order(CreateOrderDto createOrderDto)
    {
        return new Order
        {
            Description = createOrderDto.Description,
            Quantity = createOrderDto.Quantity,
            EquipmentId = createOrderDto.EquipmentId,
            Status = createOrderDto.Status,
            ProductId = createOrderDto.ProductId,
        };
    }
}