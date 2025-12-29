using CarAccessories.Application.Interfaces;
using CarAccessories.Domain.Interfaces;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarAccessories.Infrastructure.Services;

public class MediaFileService:IMediaFileService
{
    public Task<string> SaveMediaAsync<T>(IFormFile formFile, int entityId, DbSet<T> attachableDbSet, bool overwrite = true,
        int? displayOrder = null, CancellationToken ct = default) where T : class, IMediaAttachable
    {
        throw new NotImplementedException();
    }
}