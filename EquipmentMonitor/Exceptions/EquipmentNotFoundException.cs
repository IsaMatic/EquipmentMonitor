namespace EquipmentMonitor.Exceptions;

public class EquipmentNotFoundException(int id) : Exception("Equipment not found: " + id);