namespace CarAccessories.Application.Models.Auth;

public class TokenResponseModel
{
    public string? AccessToken { get; init; }
    public string? RefreshToken { get; init; }
    public DateTimeOffset AccessTokenExpiration { get; init; }
    public DateTimeOffset RefreshTokenExpiration { get; init; }
}