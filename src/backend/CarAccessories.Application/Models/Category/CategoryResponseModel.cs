using CarAccessories.Domain.Common;

namespace CarAccessories.Application.Models.Category;

public class CategoryResponseModel:BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentId { get; set; }
}