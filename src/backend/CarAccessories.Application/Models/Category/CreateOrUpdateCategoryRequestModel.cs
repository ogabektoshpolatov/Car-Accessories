using CarAccessories.Application.Models.Base;
using CarAccessories.Domain.Common;

namespace CarAccessories.Application.Models.Category;

public class CreateOrUpdateCategoryRequestModel:BaseAuditResponseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentId { get; set; }
}