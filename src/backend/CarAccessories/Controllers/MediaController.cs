using CarAccessories.Application.Interfaces;
using CarAccessories.Domain.Entities;
using CarAccessories.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Server.Controllers;

public class MediaController(IMediaFileService mediaFileService) : ControllerBase
{
    [HttpGet("{uniqueName}")]
    public async Task<IActionResult> GetMediaFileAsync(
        string uniqueName,
        CancellationToken ct = default)
    {
        var mediaFile = await mediaFileService.GetMediaFileAsync(uniqueName, ct);

        return File(mediaFile.fileBytes, mediaFile.contentType, mediaFile.fileOriginalName);
    }
}