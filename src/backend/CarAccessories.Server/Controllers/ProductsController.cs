using CarAccessories.Application.Common.ResponseData;
using CarAccessories.Application.Interfaces;
using CarAccessories.Application.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController(IProductService productService):ControllerBase
{
    [HttpPost("griddata")]
    public async Task<ResponseData<List<ProductResponseModel>>> GetAllProduct(CancellationToken ct) =>
        await productService.GetAllAsync(ct);

    [HttpPost]
    public async Task<ResponseData<int>> CreateProduct(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct) =>
        await productService.CreateAsync(requestModel, ct);
}