
using System.Net;
using CarAccessories.Shared.Responses;

namespace CarAccessories.Components.Pages;

public partial class Home
{
    private CategoryResponseModel[] categories;

    protected override async Task OnInitializedAsync()
    {
        categories = await WebRequestMethods.Http.GetFromJsonAsync<CategoryResponseModel[]>("WeatherForecast");
    }
}