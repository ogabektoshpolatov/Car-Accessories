namespace CarAccessories.Application.Models.Category;

public class CategoryDetailResponseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentId { get; set; }
}