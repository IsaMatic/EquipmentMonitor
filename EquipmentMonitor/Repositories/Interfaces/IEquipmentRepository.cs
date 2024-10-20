using EquipmentMonitor.Models.Entities;

namespace EquipmentMonitor.Repositories.Interfaces;

public interface IEquipmentRepository
{
    Task<Equipment> GetEquipmentById(int id);
    Task<IEnumerable<Equipment>> GetAllEquipments();
    Task UpdateEquipmentState(int id, EquipmentState newState);
    Task<IEnumerable<Order>> GetOrdersByEquipmentId(int equipmentId);
    Task AddOrderToEquipment(int equipmentId, int orderId);
    Task DeleteOrderFromEquipment(int equipmentId, int orderId);
}