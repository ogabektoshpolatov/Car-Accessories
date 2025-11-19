using CarAccessories.Domain.Common;

namespace CarAccessories.Domain.Entities;

public class AuthRole
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string NormalizedName { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public ICollection<AuthUserRole> AuthUserRoles { get; set; } = new List<AuthUserRole>();
}