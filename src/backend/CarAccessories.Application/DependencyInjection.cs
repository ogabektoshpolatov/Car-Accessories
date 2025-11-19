using CarAccessories.Application.Interfaces.Product;
using CarAccessories.Application.Services.Product;
using Microsoft.Extensions.DependencyInjection;

namespace CarAccessories.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}