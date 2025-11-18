namespace CarAccessories.Domain.Entities;

public class AuthUserRefreshToken
{
    public int Id { get; set; }
    public required string RefreshToken { get; set; }
    public int UserId { get; set; }
    public virtual AuthUser? User { get; set; }
    public string? DeviceId { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}