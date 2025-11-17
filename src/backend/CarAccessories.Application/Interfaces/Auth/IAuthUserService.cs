using CarAccessories.Application.Models.Auth;

namespace CarAccessories.Application.Interfaces.Auth;

public interface IAuthUserService
{
    Task<RegisterResponseModel> RegisterAsync(RegisterRequestModel registerRequest, CancellationToken ct = default);
}