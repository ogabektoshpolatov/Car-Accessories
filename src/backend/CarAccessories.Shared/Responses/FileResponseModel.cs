using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Responses;

public class FileResponseModel:BaseAuditResponseModel
{
    public int ProductId { get; set; }
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public long FileSize { get; set; }
    public string ContentType { get; set; } = null!;
}