using EquipmentMonitor.Models.Entities;

namespace EquipmentMonitor.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetOrderById(int id);
    Task<IEnumerable<Order>> GetAllOrders();
    Task<Order> CreateOrder(Order order);
    Task UpdateOrderStatus(int id, OrderStatus newStatus);
    Task UpdateQuantity(int id, int newQuantity);
    Task UpdateProduct(int id, int productId);
}