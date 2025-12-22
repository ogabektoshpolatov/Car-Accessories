
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Application.Interfaces;

public interface ICategoryService
{
    Task<bool> CreateAsync(CreateOrUpdateCategoryRequestModel requestOrUpdateProductModel, CancellationToken ct = default);
    Task<List<CategoryResponseModel>> GetAllAsync(CancellationToken ct = default);
    Task<CategoryDetailResponseModel> GetByIdAsync(int categoryId, CancellationToken ct = default);
    Task<CategoryDetailResponseModel> UpdateAsync(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct = default);
    Task<bool> DeleteAsync(int categoryId, CancellationToken ct = default);
}