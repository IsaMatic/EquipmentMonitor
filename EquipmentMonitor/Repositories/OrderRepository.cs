using EquipmentMonitor.Data;
using EquipmentMonitor.Exceptions;
using EquipmentMonitor.Models.Entities;
using EquipmentMonitor.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitor.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly EquipmentMonitorDbContext _context;
    
    public OrderRepository(EquipmentMonitorDbContext context)
    {
        _context = context;
    }
    
    public async Task<Order> GetOrderById(int id)
    {
         var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
         if (order == null) throw new OrderNotFoundException(id);
         return order;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task UpdateOrderStatus(int id, OrderStatus newStatus)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) throw new OrderNotFoundException(id);
        order.Status = newStatus;
        await _context.SaveChangesAsync();
    }
    
    public async Task<Order> CreateOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task UpdateQuantity(int id, int newQuantity)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) throw new OrderNotFoundException(id);
        order.Quantity = newQuantity;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProduct(int id, int productId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) throw new OrderNotFoundException(id);
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        if (product == null) throw new ProductNotFoundException(productId);
        order.ProductId = productId;
        
        await _context.SaveChangesAsync();
    }
}