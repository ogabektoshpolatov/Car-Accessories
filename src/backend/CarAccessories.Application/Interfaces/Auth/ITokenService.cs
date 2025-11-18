using CarAccessories.Application.Models.Auth;
using CarAccessories.Domain.Entities;

namespace CarAccessories.Application.Interfaces.Auth;

public interface ITokenService
{
    Task<TokenResponseModel> GenerateTokenAsync(AuthUser foundUser, IList<string> roles, string? deviceId, CancellationToken ct = default);
    Task<TokenResponseModel> RefreshTokenAsync(string refreshToken, CancellationToken ct = default);
    Task<bool> DeleteRefreshTokenAsync(string refreshToken, CancellationToken ct = default);
}