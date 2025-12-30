using Microsoft.AspNetCore.Http;

namespace CarAccessories.Shared.Helpers;

public static class FileHelper
{
    public static async Task WriteFileAsync(IFormFile file, string filePath, CancellationToken ct = default)
    {
        var directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        await using var fileStream = new FileStream(filePath,
            FileMode.OpenOrCreate,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 4096,
            useAsync: true);
        await file.CopyToAsync(fileStream, ct);
    }
    public static async Task WriteFileAsync(
        byte[] fileBytes,
        string filePath,
        CancellationToken ct = default)
    {
        var directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        await File.WriteAllBytesAsync(filePath, fileBytes, ct);
    }
    //public static async Task DeleteFileAsync(string filePath)
    //{
    //    if (File.Exists(filePath))
    //    {
    //        await Task.Run(() => File.Delete(filePath));
    //    }
    //}

    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}