namespace WorkerHub.Services;

public interface IFileStorageService
{
    string Save(IFormFile file, string subfolder);
    void Delete(string? imageUrl);
}