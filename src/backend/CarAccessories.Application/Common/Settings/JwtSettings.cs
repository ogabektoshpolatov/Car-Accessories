using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CarAccessories.Application.Common.Settings;

public class JwtSettings
{
    public int ExpireMinutes { get; init; } 
    public int ExpireMinutesRefresh { get; init; }
    public string? Issuer { get; init; } 
    public string? Audience { get; init; }
    public int MaxDeviceCount { get; init; }
    public string? SecretKey { get; init; }
    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        if (string.IsNullOrWhiteSpace(SecretKey))
            throw new InvalidOperationException("SecretKey is not configured.");

        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
    }
}