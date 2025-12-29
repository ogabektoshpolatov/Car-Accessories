namespace CarAccessories.Application.Interfaces;

public interface IMediaPathResolverService
{
    string GetStoragePath(Type entityType);
    string GetStoragePath(string nameofRootFolder);
}