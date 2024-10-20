using EquipmentMonitor.Models.Dtos;
using EquipmentMonitor.Models.Entities;
using EquipmentMonitor.Repositories.Interfaces;
using EquipmentMonitor.Services.Interfaces;

namespace EquipmentMonitor.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository _equipmentRepository;
    
    public EquipmentService(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }
    
    public async Task<Equipment> GetEquipmentById(int id)
    {
        return await _equipmentRepository.GetEquipmentById(id);
    }

    public async Task<IEnumerable<Equipment>> GetAllEquipments()
    {
        return await _equipmentRepository.GetAllEquipments();
    }

    public async Task UpdateEquipmentState(int id, EquipmentStateDto newState)
    {
        await _equipmentRepository.UpdateEquipmentState(id, newState.State);
    }
    
    public async Task<IEnumerable<Order>> GetOrdersByEquipmentId(int equipmentId)
    {
        return await _equipmentRepository.GetOrdersByEquipmentId(equipmentId);
    }

    public async Task AddOrderToEquipment(int equipmentId, int orderId)
    { 
        await _equipmentRepository.AddOrderToEquipment(equipmentId, orderId);
    }

    public async Task DeleteOrderFromEquipment(int equipmentId, int orderId)
    {
        await _equipmentRepository.DeleteOrderFromEquipment(equipmentId, orderId);
    }
}