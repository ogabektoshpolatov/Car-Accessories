using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CarAccessories.Application.Services;

public class MediaFileService(IApplicationDbContext dbContext, IMapper mapper) : IMediaFileService
{
    public Task<string> SaveMediaAsync<T>(IFormFile formFile, int entityId, DbSet<T> attachableDbSet, bool overwrite = true,
        int? displayOrder = null, CancellationToken ct = default) where T : class, IMediaAttachable
    {
        throw new NotImplementedException();
    }
}