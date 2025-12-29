using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities;

public class MediaFile : BaseAuditableEntity
{
    public required string Path { get; set; }
    public required string FileOriginalName { get; set; }
    public required string UniqueName { get; set; }
    public required string ContentType { get; set; }
    public long FileSize { get; set; }
    public int? DisplayOrder { get; set; }
}