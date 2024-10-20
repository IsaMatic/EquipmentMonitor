using EquipmentMonitor.Exceptions;
using EquipmentMonitor.Models.Dtos;
using EquipmentMonitor.Models.Entities;
using EquipmentMonitor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EquipmentMonitor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService _equipmentService;
    
    public EquipmentController(IEquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Equipment>> GetEquipmentById(int id)
    {
        try 
        {
            var equipment = await _equipmentService.GetEquipmentById(id);
            return Ok(equipment);
        }
        catch (EquipmentNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipment>>> GetAllEquipments()
    {
        try 
        {
            var equipments = await _equipmentService.GetAllEquipments();
            return Ok(equipments);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpPost("{id}/state")]
    public async Task<ActionResult> UpdateEquipmentState(int id, EquipmentStateDto newState)
    {
        try 
        {
            await _equipmentService.UpdateEquipmentState(id, newState);
            return Ok();
        }
        catch (EquipmentNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpGet("{id}/orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByEquipmentId(int id)
    {
        try 
        {
            var orders = await _equipmentService.GetOrdersByEquipmentId(id);
            return Ok(orders);
        }
        catch (EquipmentNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message); 
        }
    }
    
    [HttpPost("{id}/orders")]
    public async Task<ActionResult> AddOrderToEquipment(int id, int orderId)
    {
        try
        {
            await _equipmentService.AddOrderToEquipment(id, orderId);
            return Ok();
        }
        catch (EquipmentNotFoundException e)
        {
            return NotFound(e.Message);
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
    
    [HttpDelete("{id}/orders/{orderId}")]
    public async Task<ActionResult> DeleteOrderFromEquipment(int id, int orderId)
    {
        try 
        {
            await _equipmentService.DeleteOrderFromEquipment(id, orderId);
            return Ok();
        }
        catch (EquipmentNotFoundException e)
        {
            return NotFound(e.Message);
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