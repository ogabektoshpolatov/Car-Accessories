using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Responses;

public class MediaFileResponseModel:BaseAuditResponseModel
{
    public string Path { get; set; }
    public required string FileOriginalName { get; set; }
    public required string UniqueName { get; set; }
    public required string ContentType { get; set; }
    public long FileSize { get; set; }
    public int? DisplayOrder { get; set; }
}
