using CarAccessories.Application.Models.Category;
using CarAccessories.Application.Models.Product;
using CarAccessories.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CarAccessories.Application.Mappings;

public class CategoryMappings:Profile
{
    public CategoryMappings()
    {
        CreateMap<Category, CategoryResponseModel>();
        CreateMap<Category, CategoryDetailResponseModel>();
    }
}