using CarAccessories.Domain.Entities;

namespace CarAccessories.Domain.Interfaces;

public interface IMediaAttachable
{
    int Id { get; }
    public ICollection<MediaFile> MediaFiles { get; set; }
}