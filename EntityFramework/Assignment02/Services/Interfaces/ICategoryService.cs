using Assignment02.DTOs.Category;

namespace Assignment02.Services
{
    public interface ICategoryService
    {
        AddCategoryResponse? Add(AddCategoryRequest addModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel? GetById(int id);
        UpdateCategoryResponse? Update(int id, UpdateCategoryRequest updateModel);
        CategoryViewModel? Delete(int id);
    }
}