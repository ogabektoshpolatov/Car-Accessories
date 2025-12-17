using CarAccessories.Application.Models.Base;

namespace CarAccessories.Application.Models.Product;

public class ProductResponseModel:BaseAuditResponseModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}