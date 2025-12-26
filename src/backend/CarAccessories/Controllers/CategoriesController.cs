using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Common.ResponseData;
using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Server.Controllers;

public class CategoriesController(ICategoryService categoryService):BaseController
{
    [HttpPost]
    public async Task<ResponseData<PageList<CategoryResponseModel>>> GetAllCategory(
        FilterRequest filterRequest, 
        CancellationToken ct) 
        => await categoryService.GetAllAsync(filterRequest, ct);
    
    [HttpGet("{categoryId}")]
    public async Task<ResponseData<CategoryDetailResponseModel>> GetProductById([FromRoute] int categoryId, CancellationToken ct) 
        => await categoryService.GetByIdAsync(categoryId, ct);

    [HttpPost]
    public async Task<ResponseData<bool>> CreateCategory(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct) 
        => await categoryService.CreateAsync(requestModel, ct);
    
    [HttpPut]
    public async Task<ResponseData<CategoryDetailResponseModel>> UpdateProduct(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct) 
        => await categoryService.UpdateAsync(requestModel, ct);
    
    [HttpDelete("{categoryId}")]
    public async Task<ResponseData<bool>> DeleteProductById([FromRoute] int categoryId, CancellationToken ct)
        => await categoryService.DeleteAsync(categoryId, ct);
}