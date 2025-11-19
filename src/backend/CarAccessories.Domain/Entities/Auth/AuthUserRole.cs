namespace CarAccessories.Domain.Entities;

public class AuthUserRole
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public AuthUser AuthUser { get; set; }
    public AuthRole AuthRole { get; set; }
}