using WorkerHub.ViewModels.Categories;

namespace WorkerHub.Services;

public interface ICategoryService
{
    List<CategoryListItem> GetAll();
    CategoryDetails? GetDetails(int id);
}