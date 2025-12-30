namespace CarAccessories.Application.Constants;

public static class StaticUrl
{
    public static string GetMediaFileUrl(string? uniqueName)
    {
        if (string.IsNullOrWhiteSpace(uniqueName))
            return string.Empty;

        return $"Media/GetMediaFile?fileUniqueName={uniqueName}";
    }
}