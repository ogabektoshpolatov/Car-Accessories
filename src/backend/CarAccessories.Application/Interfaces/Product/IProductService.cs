using CarAccessories.Application.Models.Product;

namespace CarAccessories.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductResponseModel>> GetAllAsync(CancellationToken ct = default);
    Task<bool> CreateAsync(CreateOrUpdateProductRequestModel requestOrUpdateProductModel, CancellationToken ct = default);
    Task<ProductDetailResponseModel> GetByIdAsync(int productId, CancellationToken ct = default);
    Task<ProductDetailResponseModel> UpdateAsync(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct = default);
    Task<bool> DeleteAsync(int productId, CancellationToken ct = default);
}