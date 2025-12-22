using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Responses;

public class ProductResponseModel:BaseAuditResponseModel
{
    public string Name { get; set; } = null!;  
    public string? Description { get; set; } 
    public decimal Price { get; set; } 
    public decimal? OldPrice { get; set; } 
    public bool IsOnSale { get; set; }  
    public int Stock { get; set; }
}