using AutoMapper.QueryableExtensions;
using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Application.Interfaces;
using CarAccessories.Domain.Entities;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Application.Services;

public class ProductService(IApplicationDbContext dbContext, IMapper mapper):IProductService
{
    public async Task<PageList<ProductResponseModel>> GetAllAsync(FilterRequest filterRequest, CancellationToken ct = default)
    {
        var query = dbContext.Products
            .AsNoTracking()
            .Where(x => x.IsActive);

        return await query
            .ProjectTo<ProductResponseModel>(mapper.ConfigurationProvider)
            .ToPageListAsync(filterRequest, ct);
    }

    public async Task<bool> CreateAsync(CreateOrUpdateProductRequestModel requestOrUpdateProductModel, CancellationToken ct = default)
    {
        var product = new Product()
        {
            CategoryId = requestOrUpdateProductModel.CategoryId,
            Name = requestOrUpdateProductModel.Name,
            Description = requestOrUpdateProductModel.Description,
            Price = requestOrUpdateProductModel.Price,
            OldPrice = requestOrUpdateProductModel.OldPrice,
            Stock = requestOrUpdateProductModel.Stock,
            IsNew = requestOrUpdateProductModel.IsNew,
            IsActive = requestOrUpdateProductModel.IsActive,
            IsOnSale = requestOrUpdateProductModel.IsOnSale
        };
        
        var categoryExists = await dbContext.Categories
            .AnyAsync(c => c.Id == requestOrUpdateProductModel.CategoryId, ct);

        if (!categoryExists)
            throw new ArgumentException($"Category with the given ID {requestOrUpdateProductModel.CategoryId} does not exist.", nameof(requestOrUpdateProductModel));
        
        await dbContext.Products.AddAsync(product, ct);
        return await dbContext.SaveChangesAsync(ct) > 0;
    }

    public async Task<ProductDetailResponseModel> GetByIdAsync(int productId, CancellationToken ct = default)
    {
        var foundProduct = await dbContext.Products
            .AsNoTracking()
            .Where(p => p.Id == productId)
            .ProjectTo<ProductDetailResponseModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(ct);
        
        if(foundProduct is null)
            throw new ArgumentException($"Product with ID {productId} does not exist.", nameof(productId));
        return foundProduct;
    }

    public async Task<ProductDetailResponseModel> UpdateAsync(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct = default)
    {
        if (requestModel.Id <= 0)
            throw new ArgumentException("Id must be greater than zero.", nameof(requestModel));
        
        var entity = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == requestModel.Id, ct);
        
        if(entity is null)
            throw new ArgumentException($"Product with ID {requestModel.Id} does not exist.", nameof(requestModel));
        
        var categoryExists = await dbContext.Categories
            .AnyAsync(c => c.Id == requestModel.CategoryId, ct);

        if (!categoryExists)
            throw new ArgumentException($"Category with the given ID {requestModel.CategoryId} does not exist.", nameof(requestModel));
        
        mapper.Map(requestModel, entity);

        await dbContext.SaveChangesAsync(ct);

        return mapper.Map<ProductDetailResponseModel>(entity);
    }

    public async Task<bool> DeleteAsync(int productId, CancellationToken ct = default)
    {
        var entity = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId, ct);
        
        if(entity is null)
            throw new ArgumentException($"Product with ID {productId} does not exist.", nameof(productId));
        
        dbContext.Products.Remove(entity);
        return await dbContext.SaveChangesAsync(ct) > 0;
    }
}