using CarAccessories.Application.Models.Product;

namespace CarAccessories.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductResponseModel>> GetAllAsync(CancellationToken ct = default);
}