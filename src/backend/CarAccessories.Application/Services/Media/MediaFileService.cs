using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using CarAccessories.Domain.Entities;
using CarAccessories.Shared.Helpers;

namespace CarAccessories.Application.Services;

public class MediaFileService(IMediaPathResolverService pathResolverService, IApplicationDbContext dbContext, IMapper mapper) : IMediaFileService
{
    public async Task<string> SaveMediaAsync<T>(IFormFile formFile, int entityId, DbSet<T> attachableDbSet, bool overwrite = true,
        int? displayOrder = null, CancellationToken ct = default) where T : class, IMediaAttachable
    {
        if (formFile is { Length: 0 })
            throw new ArgumentException("Invalid file.", nameof(formFile));

        if (entityId <= 0)
            throw new ArgumentException($"Invalid {typeof(T).Name} ID.", nameof(entityId));

        var mediaAttachable = await attachableDbSet
            .AsTracking()
            .Include(x => x.MediaFiles)
            .FirstOrDefaultAsync(x => x.Id == entityId, ct);

        if (mediaAttachable is null)
            throw new ArgumentException($"Entity with ID {entityId} does not exist.", nameof(entityId));

        var uniqueId = Ulid.NewUlid().ToString();
        var fileUniqueName = uniqueId + Path.GetExtension(formFile.FileName);
        var fullPath = Path.Combine(pathResolverService.GetStoragePath(typeof(T)), fileUniqueName);

        try
        {
            if (overwrite)
            {
                var fileToReplace = displayOrder.HasValue
                    ? mediaAttachable.MediaFiles.FirstOrDefault(f => f.DisplayOrder == displayOrder.Value)
                    : mediaAttachable.MediaFiles.FirstOrDefault();

                if (fileToReplace is not null)
                {
                    FileHelper.DeleteFile(fileToReplace.Path);
                    dbContext.MediaFiles.Remove(fileToReplace);
                    mediaAttachable.MediaFiles.Remove(fileToReplace);
                }
            }

            await FileHelper.WriteFileAsync(formFile, fullPath, ct);

            var mediaFile = new MediaFile
            {
                Path = fullPath,
                FileOriginalName = formFile.FileName,
                UniqueName = fileUniqueName,
                ContentType = formFile.ContentType,
                FileSize = formFile.Length,
                DisplayOrder = displayOrder
            };

            mediaAttachable.MediaFiles.Add(mediaFile);

            await dbContext.SaveChangesAsync(ct);

            return mediaFile.UniqueName;
        }
        catch (Exception ex)
        {
            FileHelper.DeleteFile(fullPath); // Clean up partially saved file
            throw new InvalidOperationException("Failed to save media file.", ex);
        }
    }
}