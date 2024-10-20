using EquipmentMonitor.Models.Dtos;
using EquipmentMonitor.Models.Entities;
using EquipmentMonitor.Repositories.Interfaces;
using EquipmentMonitor.Services.Interfaces;

namespace EquipmentMonitor.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<Order> GetOrderById(int id)
    {
        return await _orderRepository.GetOrderById(id);
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _orderRepository.GetAllOrders();   
    }
    
    public async Task<Order> CreateOrder(CreateOrderDto order)
    {
        return await _orderRepository.CreateOrder(order);
    }

    public async Task UpdateOrderStatus(int id, OrderStatus newStatus)
    {
        await _orderRepository.UpdateOrderStatus(id, newStatus);
    }

    public async Task UpdateQuantity(int id, int newQuantity)
    {
        await _orderRepository.UpdateQuantity(id, newQuantity);
    }

    public async Task UpdateProduct(int id, int productId)
    {
        await _orderRepository.UpdateProduct(id, productId);
    }
}