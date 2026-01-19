using CarAccessories.Application.Common.QueryFilter;
using CarAccessories.Application.Services;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Components.Layout;

public partial class ShopLayout
{
    private List<CategoryResponseModel>? categories;
    private bool isLoading = true;
    private string? errorMessage;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            var categoryFilter = new FilterRequest
            {
                PageIndex = 0,
                PageSize = 12
            };
            var categoryResult = await CategoryService.GetAllAsync(categoryFilter);
            categories = categoryResult.Items;
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
}