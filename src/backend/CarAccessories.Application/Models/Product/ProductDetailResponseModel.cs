namespace CarAccessories.Application.Models.Product;

public class ProductDetailResponseModel
{
    public string Name { get; set; } = null!;  
    public string? Description { get; set; } 
    public decimal Price { get; set; } 
    public decimal? OldPrice { get; set; } 
    public bool IsOnSale { get; set; }  
    public int Stock { get; set; }
}