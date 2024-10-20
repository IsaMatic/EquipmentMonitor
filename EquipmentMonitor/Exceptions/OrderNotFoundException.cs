namespace EquipmentMonitor.Exceptions;

public class OrderNotFoundException(int id) : Exception("Order not found: " + id);