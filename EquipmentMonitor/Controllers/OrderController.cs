using EquipmentMonitor.Exceptions;
using EquipmentMonitor.Models.Dtos;
using EquipmentMonitor.Models.Entities;
using EquipmentMonitor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentMonitor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        try {
            var order = await _orderService.GetOrderById(id);
            return Ok(order);
        }
        catch (OrderNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
    {
        try {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto order)
    {
        try {
            var newOrder = await _orderService.CreateOrder(order);
            return Ok(newOrder);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpPost("{id}/status")]
    public async Task<ActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatus newStatus)
    {
        try {
            await _orderService.UpdateOrderStatus(id, newStatus);
            return Ok();
        }
        catch (OrderNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpPost("{id}/quantity")]
    public async Task<ActionResult> UpdateQuantity(int id, [FromBody] int newQuantity)
    {
        try {
            await _orderService.UpdateQuantity(id, newQuantity);
            return Ok();
        }
        catch (OrderNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpPost("{id}/product")]
    public async Task<ActionResult> UpdateProduct(int id, int productId)
    {
        try {
            await _orderService.UpdateProduct(id, productId);
            return Ok();
        }
        catch (OrderNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
}