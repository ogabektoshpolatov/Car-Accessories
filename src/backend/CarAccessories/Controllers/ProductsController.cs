using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Common.ResponseData;
using CarAccessories.Application.Interfaces;
using CarAccessories.Shared.Requests;
using CarAccessories.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarAccessories.Controllers;

public class ProductsController(IProductService productService):BaseController
{
    [HttpPost]
    public async Task<ResponseData<PageList<ProductResponseModel>>> GetAll(
        FilterRequest filterRequest, 
        CancellationToken ct) 
        => await productService.GetAllAsync(filterRequest,ct);
    
    [HttpGet]
    public async Task<ResponseData<ProductDetailResponseModel>> GetById(int productId, CancellationToken ct) 
        => await productService.GetByIdAsync(productId, ct);

    [HttpPost]
    public async Task<ResponseData<bool>> Create(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct) 
        => await productService.CreateAsync(requestModel, ct);
    
    [HttpPut]
    public async Task<ResponseData<ProductDetailResponseModel>> Update(CreateOrUpdateProductRequestModel requestModel, CancellationToken ct) 
        => await productService.UpdateAsync(requestModel, ct);
    
    [HttpDelete("{productId}")]
    public async Task<ResponseData<bool>> DeleteById([FromRoute] int productId, CancellationToken ct) 
        => await productService.DeleteAsync(productId, ct);

    [HttpPut]
    public async Task<ResponseData<string>> UpdateImage(int productId, int displayOrder, IFormFile image, CancellationToken ct)
        => new() { Result = await productService.ReplaceProductImageAsync(productId, displayOrder, image, ct) };
    
    [HttpPost]
    public async Task<ResponseData<List<string>>> UploadImages(int productId, List<IFormFile> images, CancellationToken ct)
        => new() { Result = await productService.UploadImagesAsync(productId, images, ct) };
    
    [HttpDelete("{productId}")]
    public async Task<ResponseData<bool>> DeleteAllImages([FromRoute] int productId, CancellationToken ct)
         => await productService.DeleteAllImageAsync(productId, ct);
}