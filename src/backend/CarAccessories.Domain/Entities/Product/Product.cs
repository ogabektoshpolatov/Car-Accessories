using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities;

public class Product:BaseEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public int Stock { get; set; }
    public bool IsNew { get; set; }
    public bool IsOnSale { get; set; }
    public bool IsActive { get; set; } = true;
    public Category Category { get; set; } = null!;
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
}