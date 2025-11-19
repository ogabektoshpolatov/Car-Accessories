namespace CarAccessories.Application.Models.Product;

public class CreateProductRequestModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}