using CarAccessories.Application.Models.Product;

namespace CarAccessories.Application.Interfaces.Product;

public interface IProductService
{
    Task<List<ProductResponseModel>> GetAllAsync(CancellationToken ct = default);
}