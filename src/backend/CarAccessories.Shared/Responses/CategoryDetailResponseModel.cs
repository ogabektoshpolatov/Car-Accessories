using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Responses;

public class CategoryDetailResponseModel:BaseAuditResponseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentId { get; set; }
}