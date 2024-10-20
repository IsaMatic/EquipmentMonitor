using EquipmentMonitor.Models.Dtos;
using EquipmentMonitor.Models.Entities;

namespace EquipmentMonitor.Services.Interfaces;

public interface IOrderService
{
    Task<Order> GetOrderById(int id);
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> CreateOrder(CreateOrderDto order);
    Task UpdateOrderStatus(int id, OrderStatus newStatus);
    Task UpdateQuantity(int id, int newQuantity);
    Task UpdateProduct(int id, int productId);
    
}