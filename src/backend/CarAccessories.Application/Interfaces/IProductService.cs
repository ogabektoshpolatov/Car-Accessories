using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Http;

namespace CarAccessories.Application.Interfaces;

public interface IProductService
{
    Task<PageList<ProductResponseModel>> GetAllAsync(FilterRequest filterRequest, CancellationToken ct = default);
    Task<bool> CreateAsync(CreateOrUpdateProductRequestModel requestOrUpdateProductModel, CancellationToken ct = default);
    Task<ProductDetailResponseModel> GetByIdAsync(int productId, CancellationToken ct = default);
    Task<ProductDetailResponseModel> UpdateAsync(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct = default);
    Task<bool> DeleteAsync(int productId, CancellationToken ct = default);
    Task<string> ReplaceProductImageAsync(int productId, int displayOrder, IFormFile image, CancellationToken ct = default);
    Task<bool> DeleteAllImageAsync(int productId, CancellationToken ct = default);
    Task<List<string>> UploadImagesAsync(int productId, List<IFormFile> images, CancellationToken ct = default);
}