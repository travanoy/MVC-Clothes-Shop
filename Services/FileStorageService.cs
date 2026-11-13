namespace WorkerHub.Services;

public class FileStorageService(IWebHostEnvironment env) : IFileStorageService
{
    public string Save(IFormFile file, string subfolder)
    {
        var assetsPath = Path.Combine(env.WebRootPath, "Assets", subfolder);
        Directory.CreateDirectory(assetsPath);

        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(assetsPath, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);

        return $"/Assets/{subfolder}/{fileName}";
    }

    public void Delete(string? imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl))
            return;

        var filePath = Path.Combine(env.WebRootPath, imageUrl.TrimStart('/'));
        if (System.IO.File.Exists(filePath))
            System.IO.File.Delete(filePath);
    }
}