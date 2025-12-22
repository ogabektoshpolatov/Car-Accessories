using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Requests;

public class CreateOrUpdateCategoryRequestModel:BaseAuditResponseModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentId { get; set; }
}