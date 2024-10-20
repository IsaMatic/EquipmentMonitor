using EquipmentMonitor.Models.Dtos;
using EquipmentMonitor.Models.Entities;

namespace EquipmentMonitor.Services.Interfaces;

public interface IEquipmentService
{
    Task<Equipment> GetEquipmentById(int id);
    Task<IEnumerable<Equipment>> GetAllEquipments();
    Task UpdateEquipmentState(int id, EquipmentStateDto newState);
    
    Task<IEnumerable<Order>> GetOrdersByEquipmentId(int equipmentId);
    
    Task AddOrderToEquipment(int equipmentId, int orderId);
    Task DeleteOrderFromEquipment(int equipmentId, int orderId);
}