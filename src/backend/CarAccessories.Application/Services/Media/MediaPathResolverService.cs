using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace CarAccessories.Application.Services;

public class MediaPathResolverService(IHostingEnvironment env, IConfiguration configuration) : IMediaPathResolverService
{
    public string GetStoragePath(Type entityType)
    {
        string basePath = env.IsDevelopment()   
            ? Path.Combine(env.WebRootPath, "media")
            : Path.Combine(configuration["BasePath"] ?? "/var/www/media");
       
        return Path.Combine(basePath, entityType.Name.FromCamelCaseToSnakeCase());
    }

    public string GetStoragePath(string nameofRootFolder)
    {
        string basePath = env.IsDevelopment()   
            ? Path.Combine(env.WebRootPath, "media")
            : Path.Combine(configuration["BasePath"] ?? "/var/www/media");
       
        return Path.Combine(basePath, nameofRootFolder.FromCamelCaseToSnakeCase());
    }
}
