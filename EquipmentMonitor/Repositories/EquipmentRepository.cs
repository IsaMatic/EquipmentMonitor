using EquipmentMonitor.Data;
using EquipmentMonitor.Exceptions;
using EquipmentMonitor.Models.Entities;
using EquipmentMonitor.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitor.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly EquipmentMonitorDbContext _context;
    
    public EquipmentRepository(EquipmentMonitorDbContext context)
    {
        _context = context;
    }

    public async Task<Equipment> GetEquipmentById(int id)
    {
        var equipment = await _context.Equipments
            .Include(e => e.Orders)
            .ThenInclude(o => o.Product)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (equipment == null) throw new EquipmentNotFoundException(id);
        return equipment;
    }

    public async Task<IEnumerable<Equipment>> GetAllEquipments()
    {
        return await _context.Equipments
            .Include(e => e.Orders)
            .ThenInclude(o => o.Product)
            .ToListAsync();
    }

    public async Task UpdateEquipmentState(int id, EquipmentState newState)
    {
        var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);
        if (equipment == null) throw new EquipmentNotFoundException(id);
        equipment.State = newState;
        Console.WriteLine(equipment.State);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByEquipmentId(int equipmentId)
    {
        var equipment = await _context.Equipments
            .Include(equipment => equipment.Orders)
            .ThenInclude(o => o.Product)
            .FirstOrDefaultAsync(e => e.Id == equipmentId);
        if (equipment == null) throw new EquipmentNotFoundException(equipmentId);
        return equipment.Orders;
    }

    public async Task AddOrderToEquipment(int equipmentId, int orderId)
    {
        var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == equipmentId);
        if (equipment == null) throw new EquipmentNotFoundException(equipmentId);
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        if (order == null) throw new OrderNotFoundException(orderId);
        // TODO: Check if order is already added to equipment / another equipment
        order.EquipmentId = equipmentId;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderFromEquipment(int equipmentId, int orderId)
    {
        var equipment = _context.Equipments.Include(equipment => equipment.Orders).FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null) throw new EquipmentNotFoundException(equipmentId);
        var order = equipment.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null) throw new OrderNotFoundException(orderId);
        equipment.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}