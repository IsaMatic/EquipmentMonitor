using EquipmentMonitor.Models.Entities;

namespace EquipmentMonitor.Models.Dtos;

public record EquipmentStateDto
{
    public EquipmentState State { get; set; }
}