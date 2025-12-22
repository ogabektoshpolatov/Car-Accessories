using CarAccessories.Domain.Entities;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.Extensions.Caching.Memory;

namespace CarAccessories.Application.Mappings;

public class CategoryMappings:Profile
{
    public CategoryMappings()
    {
        CreateMap<Category, CategoryResponseModel>();
        CreateMap<Category, CategoryDetailResponseModel>()
            .ForMember(
                dest => dest.ParentCategory, 
                opt => opt.MapFrom(src => src.Parent));
        CreateMap<CreateOrUpdateCategoryRequestModel, Category>();;
    }
}