using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Requests;

public class CreateOrUpdateCategoryRequestModel : BaseRequestModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ParentId { get; set; }
}