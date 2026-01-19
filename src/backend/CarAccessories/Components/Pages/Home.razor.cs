using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Components.Pages;

public partial class Home
{
    private List<CategoryResponseModel>? categories;
    private List<ProductResponseModel>? products;
    private bool isLoading = true;
    private string? errorMessage;
    private int newProductCount;
    private int saleProductCount;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            // Load categories
            var categoryFilter = new FilterRequest
            {
                PageIndex = 0,
                PageSize = 12
            };
            var categoryResult = await CategoryService.GetAllAsync(categoryFilter);
            categories = categoryResult.Items;

            // Load products
            var productFilter = new FilterRequest
            {
                PageIndex = 0,
                PageSize = 12
            };
            var productResult = await ProductService.GetAllAsync(productFilter);
            products = productResult.Items;

            // Calculate stats
            newProductCount = products?.Count(p => p.IsNew) ?? 0;
            saleProductCount = products?.Count(p => p.IsOnSale) ?? 0;
        }
        catch (Exception ex)
        {
            errorMessage = $"Failed to load data: {ex.Message}";
            Console.WriteLine($"Error in Home.OnInitializedAsync: {ex}");
        }
        finally
        {
            isLoading = false;
        }
    }

    private void NavigateToCategory(int categoryId)
    {
        // TODO: Implement navigation
        Console.WriteLine($"Navigate to category: {categoryId}");
    }

    private void ViewProduct(int productId)
    {
        // TODO: Implement navigation
        Console.WriteLine($"View product: {productId}");
    }

    private void AddToCart(int productId)
    {
        // TODO: Implement add to cart
        Console.WriteLine($"Add to cart: {productId}");
    }
}