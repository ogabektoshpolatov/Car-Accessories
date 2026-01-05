using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Common.ResponseData;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Controllers;

public class MediaController(IMediaFileService mediaFileService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetMediaFile(string uniqueName, CancellationToken ct = default)
    {
        var mediaFile = await mediaFileService.GetMediaFileAsync(uniqueName, ct);
    
        return File(mediaFile.fileBytes, mediaFile.contentType, mediaFile.fileOriginalName);
    }
    
    [HttpDelete]
    public async Task<ResponseData<bool>> DeleteMediaFile(string uniqueName, CancellationToken ct = default)
        => await mediaFileService.DeleteMediaFileAsync(uniqueName, ct);
    
}