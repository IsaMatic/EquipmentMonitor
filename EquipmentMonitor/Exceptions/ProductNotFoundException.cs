namespace EquipmentMonitor.Exceptions;

public class ProductNotFoundException(int id) : Exception("Product not found: " + id);