using System.Text.Json.Serialization;

namespace CarAccessories.Shared.Common;

public class BaseAuditResponseModel
{
    [JsonPropertyOrder(1)]
    public int Id { get; set; }

    [JsonPropertyOrder(99)]
    public DateTime Created { get; set; }
    [JsonPropertyOrder(100)]
    public string? CreatedByFullName { get; set; }

    [JsonPropertyOrder(101)]
    public DateTime LastModified { get; set; }
    [JsonPropertyOrder(102)]
    public string? LastModifiedByFullName { get; set; }
    [JsonPropertyOrder(103)]
    public bool IsActive { get; set; }
}