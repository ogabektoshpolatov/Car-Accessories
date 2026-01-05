using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Common.ResponseData;
using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Controllers;

public class CategoriesController(ICategoryService categoryService):BaseController
{
    [HttpPost]
    public async Task<ResponseData<PageList<CategoryResponseModel>>> GetAll(
        FilterRequest filterRequest, 
        CancellationToken ct) 
        => await categoryService.GetAllAsync(filterRequest, ct);
    
    [HttpGet("{categoryId}")]
    public async Task<ResponseData<CategoryDetailResponseModel>> GetById([FromRoute] int categoryId, CancellationToken ct) 
        => await categoryService.GetByIdAsync(categoryId, ct);

    [HttpPost]
    public async Task<ResponseData<bool>> CreateCategory(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct) 
        => await categoryService.CreateAsync(requestModel, ct);
    
    [HttpPut]
    public async Task<ResponseData<CategoryDetailResponseModel>> Update(CreateOrUpdateCategoryRequestModel requestModel, CancellationToken ct) 
        => await categoryService.UpdateAsync(requestModel, ct);
    
    [HttpDelete("{categoryId}")]
    public async Task<ResponseData<bool>> DeleteById([FromRoute] int categoryId, CancellationToken ct)
        => await categoryService.DeleteAsync(categoryId, ct);
}