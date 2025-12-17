using CarAccessories.Application.Common.Settings;
using CarAccessories.Application.Interfaces.Auth;
using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Services.Auth;
using CarAccessories.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarAccessories.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => {}, typeof(DependencyInjection).Assembly);
        
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}