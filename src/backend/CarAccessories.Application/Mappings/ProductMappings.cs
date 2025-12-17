using CarAccessories.Application.Models.Product;
using CarAccessories.Domain.Entities;

namespace CarAccessories.Application.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<Product, ProductResponseModel>();
    }
}