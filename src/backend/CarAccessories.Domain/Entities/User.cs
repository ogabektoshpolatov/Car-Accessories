namespace CarAccessories.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!; // default keyword function is => I know this property is not initialized yet, but it will be later — don’t warn me.
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}