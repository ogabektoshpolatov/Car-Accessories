using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Common.ResponseData;
using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController(IProductService productService):ControllerBase
{
    [HttpPost("griddata")]
    public async Task<ResponseData<PageList<ProductResponseModel>>> GetAllProduct(
        FilterRequest filterRequest, 
        CancellationToken ct) 
        => await productService.GetAllAsync(filterRequest,ct);
    
    [HttpGet("{productId}")]
    public async Task<ResponseData<ProductDetailResponseModel>> GetProductById(int productId, CancellationToken ct) 
        => await productService.GetByIdAsync(productId, ct);

    [HttpPost]
    public async Task<ResponseData<bool>> CreateProduct(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct) 
        => await productService.CreateAsync(requestModel, ct);
    
    [HttpPut]
    public async Task<ResponseData<ProductDetailResponseModel>> UpdateProduct(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct) 
        => await productService.UpdateAsync(requestModel, ct);
    
    [HttpDelete("{productId}")]
    public async Task<ResponseData<bool>> DeleteProductById(int productId, CancellationToken ct) 
        => await productService.DeleteAsync(productId, ct);
}