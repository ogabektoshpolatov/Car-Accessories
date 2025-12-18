using AutoMapper.QueryableExtensions;
using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Application.Models.Category;
using CarAccessories.Application.Models.Product;
using CarAccessories.Domain.Entities;

namespace CarAccessories.Application.Services;

public class CategoryService(IApplicationDbContext dbContext, IMapper mapper):ICategoryService
{
    public async Task<bool> CreateAsync(CreateOrUpdateCategoryRequestModel requestOrUpdateProductModel, CancellationToken ct = default)
    {
        var category = new Category()
        {
            Name = requestOrUpdateProductModel.Name,
            Description = requestOrUpdateProductModel.Description,
            ParentId = requestOrUpdateProductModel.ParentId,
        };
        
        await dbContext.Categories.AddAsync(category, ct);
        return await dbContext.SaveChangesAsync(ct) > 0;
    }

    public async Task<List<CategoryResponseModel>> GetAllAsync(CancellationToken ct = default)
    {
        var categories = await dbContext.Categories
            .Where(x => x.IsActive)
            .OrderByDescending(x => x.Created)
            .ToListAsync(ct);
        
        return mapper.Map<List<CategoryResponseModel>>(categories);
    }

    public async Task<CategoryDetailResponseModel> GetByIdAsync(int categoryId, CancellationToken ct = default)
    {
        var foundCategory = await dbContext.Categories
            .AsNoTracking()
            .Where(p => p.Id == categoryId)
            .ProjectTo<CategoryDetailResponseModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(ct);
        
        if(foundCategory is null)
            throw new ArgumentException($"Category with ID {categoryId} does not exist.", nameof(categoryId));
        return foundCategory;
    }

    public async Task<CategoryDetailResponseModel> UpdateAsync(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct = default)
    {
        if (requestModel.Id <= 0)
            throw new ArgumentException("Id must be greater than zero.", nameof(requestModel));
        
        var entity = await dbContext.Categories
            .FirstOrDefaultAsync(p => p.Id == requestModel.Id, ct);
        
        if(entity is null)
            throw new ArgumentException($"Category with ID {requestModel.Id} does not exist.", nameof(requestModel));
        
        mapper.Map(requestModel, entity);

        await dbContext.SaveChangesAsync(ct);

        return mapper.Map<CategoryDetailResponseModel>(entity);
    }

    public async Task<bool> DeleteAsync(int categoryId, CancellationToken ct = default)
    {
        var entity = await dbContext.Categories
            .FirstOrDefaultAsync(p => p.Id == categoryId, ct);
        
        if(entity is null)
            throw new ArgumentException($"Product with ID {categoryId} does not exist.", nameof(categoryId));
        
        dbContext.Categories.Remove(entity);
        return await dbContext.SaveChangesAsync(ct) > 1;
    }
}