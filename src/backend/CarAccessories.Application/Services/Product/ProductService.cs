using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Models.Product;

namespace CarAccessories.Application.Services.Product;

public class ProductService(IApplicationDbContext dbContext):IProductService
{
    public async Task<List<ProductResponseModel>> GetAllAsync(CancellationToken ct = default)
    {
        var products = await dbContext.Products.ToListAsync(ct);
        var productsResponse = new List<ProductResponseModel>();
        
        if(!products.Any()) return productsResponse;

        foreach (var product in products)
        {
            var productResponse = new ProductResponseModel();
            productResponse.Name = product.Name;
            productResponse.Description = product.Description;
            productResponse.Price = product.Price;
            productsResponse.Add(productResponse);
        }

        return productsResponse;
    }
}