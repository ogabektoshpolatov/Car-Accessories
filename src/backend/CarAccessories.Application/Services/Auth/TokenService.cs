using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CarAccessories.Application.Common.Constants;
using CarAccessories.Application.Common.Settings;
using CarAccessories.Application.Interfaces.Auth;
using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Application.Models.Auth;
using CarAccessories.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CarAccessories.Application.Services.Auth;

public class TokenService(IApplicationDbContext dbContext, IOptions<JwtSettings> jwtSettings):ITokenService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    public async Task<TokenResponseModel> GenerateTokenAsync(AuthUser foundUser, IList<string> roles, string? deviceId, CancellationToken ct = default)
    {
        var utcNow = DateTime.UtcNow;
        if(!foundUser.IsActive)
            throw new UnauthorizedAccessException("User is not active");
        
        var claims = new List<Claim>
        {
            new Claim(StaticClaims.UserId, foundUser.Id.ToString()),
            new Claim(StaticClaims.UserName, foundUser.UserName),
            new Claim(StaticClaims.Roles, string.Join(',', roles)),
            new Claim(StaticClaims.DeviceId, deviceId ?? string.Empty),
        };
        
        var jwtToken  = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            notBefore:utcNow ,
            expires: utcNow.Add(TimeSpan.FromMinutes(_jwtSettings.ExpireMinutes)),
            signingCredentials: new SigningCredentials(_jwtSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );
        
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return new TokenResponseModel
        {
            AccessToken = accessToken,
            RefreshToken = "",
            AccessTokenExpiration = utcNow.Add(TimeSpan.FromMinutes(_jwtSettings.ExpireMinutes)),
            RefreshTokenExpiration = utcNow.Add(TimeSpan.FromMinutes(_jwtSettings.ExpireMinutesRefresh))
        };
    }

    public Task<TokenResponseModel> RefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}