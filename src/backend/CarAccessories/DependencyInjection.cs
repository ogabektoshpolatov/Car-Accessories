using CarAccessories.Application.Common.Settings;

namespace CarAccessories;

public static class DependencyInjection
{
    public static void AddPresentation(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "CarAccessories",
                Version = "v1",
                Description = """
                              For filter:
                              {
                                "pageIndex": 0,
                                "pageSize": 40,
                                "sort": null,
                                "filter": null
                              }
                              """
            });
        });
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
    }
}