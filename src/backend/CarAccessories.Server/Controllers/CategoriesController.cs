using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Common.ResponseData;
using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController(ICategoryService categoryService):ControllerBase
{
    [HttpPost("get-all")]
    public async Task<ResponseData<PageList<CategoryResponseModel>>> GetAllCategory(
        FilterRequest filterRequest, 
        CancellationToken ct) 
        => await categoryService.GetAllAsync(filterRequest, ct);
    
    [HttpGet("{productId}")]
    public async Task<ResponseData<CategoryDetailResponseModel>> GetProductById(int productId, CancellationToken ct) 
        => await categoryService.GetByIdAsync(productId, ct);

    [HttpPost]
    public async Task<ResponseData<bool>> CreateCategory(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct) 
        => await categoryService.CreateAsync(requestModel, ct);
    
    [HttpPut]
    public async Task<ResponseData<CategoryDetailResponseModel>> UpdateProduct(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct) 
        => await categoryService.UpdateAsync(requestModel, ct);
    
    [HttpDelete("{productId}")]
    public async Task<ResponseData<bool>> DeleteProductById(int productId, CancellationToken ct)
        => await categoryService.DeleteAsync(productId, ct);
}