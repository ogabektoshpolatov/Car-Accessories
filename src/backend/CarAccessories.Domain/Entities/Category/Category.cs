using CarAccessories.Domain.Common;
    
namespace CarAccessories.Domain.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public int? ParentId { get; set; }
    public virtual Category Parent { get; set; }
    public virtual ICollection<Category> Children { get; set; } = new List<Category>();
}