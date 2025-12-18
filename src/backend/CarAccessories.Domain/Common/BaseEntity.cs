using System.ComponentModel.DataAnnotations.Schema;

namespace CarAccessories.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime LastModified { get; set; }
    public int? LastModifiedBy { get; set; }
    public bool IsActive { get; set; } = true;

    [NotMapped]
    public string? CreatedByFullName { get; set; }

    [NotMapped]
    public string? LastModifiedByFullName { get; set; }
}