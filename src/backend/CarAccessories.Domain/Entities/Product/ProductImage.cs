using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities;

public class ProductImage:BaseEntity
{
    public int ProductId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }
    public Product Product { get; set; } = null!;
}