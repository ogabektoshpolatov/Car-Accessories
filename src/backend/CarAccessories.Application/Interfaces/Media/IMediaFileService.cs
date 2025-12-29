using CarAccessories.Domain.Interfaces;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Http;

namespace CarAccessories.Application.Interfaces;

public interface IMediaFileService
{
    Task<string> SaveMediaAsync<T>(
        IFormFile formFile,
        int entityId,
        DbSet<T> attachableDbSet,
        bool overwrite = true,
        int? displayOrder = null,
        CancellationToken ct = default)
        where T : class, IMediaAttachable;
}