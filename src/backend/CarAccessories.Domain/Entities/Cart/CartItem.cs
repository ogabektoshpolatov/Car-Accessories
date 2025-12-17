using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities;

public class CartItem:BaseEntity
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } 
    public Cart Cart { get; set; } = null!;
    public Product Product { get; set; } = null!;
}