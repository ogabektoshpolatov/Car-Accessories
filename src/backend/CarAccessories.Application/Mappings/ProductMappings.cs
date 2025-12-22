using CarAccessories.Domain.Entities;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Application.Mappings;

public class ProductMappings : Profile
{
    public ProductMappings()
    {
        CreateMap<Product, ProductResponseModel>();
        CreateMap<Product, ProductDetailResponseModel>();
        CreateMap<CreateOrUpdateProductRequestModel, Product>();
    }
}