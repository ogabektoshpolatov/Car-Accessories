using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAccessories.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CarAccessoriesDb");
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite(connectionString)
                .EnableSensitiveDataLogging()); // Database loglarini olish uchun kerak. 

        services.AddScoped<IApplicationDbContext, AppDbContext>();
    }
}