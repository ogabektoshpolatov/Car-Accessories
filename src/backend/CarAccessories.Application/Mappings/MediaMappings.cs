using CarAccessories.Domain.Entities;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Application.Mappings;

public class MediaMappings:Profile
{
    public MediaMappings()
    {
        CreateMap<MediaFile, MediaFileResponseModel>();
    }
}