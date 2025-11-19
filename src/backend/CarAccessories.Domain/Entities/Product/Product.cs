using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities.Product;

public class Product:BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}