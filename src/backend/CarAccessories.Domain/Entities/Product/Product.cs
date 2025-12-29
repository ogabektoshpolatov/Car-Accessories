using CarAccessories.Domain.Common;
using CarAccessories.Domain.Interfaces;

namespace CarAccessories.Domain.Entities;

public class Product:BaseAuditableEntity, IMediaAttachable
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public int Stock { get; set; }
    public bool IsNew { get; set; }
    public bool IsOnSale { get; set; }
    public Category Category { get; set; } = null!;
    public virtual ICollection<MediaFile> MediaFiles { get; set; } = [];
}