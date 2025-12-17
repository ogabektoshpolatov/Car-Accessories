using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Models.Product;
using CarAccessories.Domain.Entities;

namespace CarAccessories.Application.Services;

public class ProductService(IApplicationDbContext dbContext, IMapper mapper):IProductService
{
    public async Task<List<ProductResponseModel>> GetAllAsync(CancellationToken ct = default)
    {
        var products = await dbContext.Products
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.Created)
            .ToListAsync(ct);

        return mapper.Map<List<ProductResponseModel>>(products);
    }

    public async Task<bool> CreateAsync(CreateOrUpdateProductRequestModel requestOrUpdateProductModel, CancellationToken ct = default)
    {
        var category = await dbContext.Categories.FindAsync(requestOrUpdateProductModel.CategoryId);
        var product = new Product()
        {
            CategoryId = requestOrUpdateProductModel.CategoryId,
            Name = requestOrUpdateProductModel.Name,
            Description = requestOrUpdateProductModel.Description,
            Price = requestOrUpdateProductModel.Price,
            OldPrice = requestOrUpdateProductModel.OldPrice,
            Slug = requestOrUpdateProductModel.Slug,
            Stock = requestOrUpdateProductModel.Stock,
            IsNew = requestOrUpdateProductModel.IsNew,
            IsActive = requestOrUpdateProductModel.IsActive,
            IsOnSale = requestOrUpdateProductModel.IsOnSale
        };
        
        await dbContext.Products.AddAsync(product, ct);
        return await dbContext.SaveChangesAsync(ct) > 1;
    }
}