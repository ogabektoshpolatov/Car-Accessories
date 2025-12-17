using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities;

public class Cart:BaseEntity
{
    public string? UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}