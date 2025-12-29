using CarAccessories.Shared.Common;

namespace CarAccessories.Shared.Responses;

public class FileUploadResponseModel:BaseAuditResponseModel
{
    public int? FileId { get; set; }
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public long FileSize { get; set; }
}