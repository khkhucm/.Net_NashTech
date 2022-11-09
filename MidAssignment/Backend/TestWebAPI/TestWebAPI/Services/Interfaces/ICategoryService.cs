using TestWebAPI.DTOs.Category;

namespace TestWebAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        CreateCategoryResponse? Create(CreateCategoryRequest addModel);
        IEnumerable<GetCategoryModel> GetAll();
        GetCategoryModel? GetById(int id);
       // UpdateCategoryResponse? Update(int id, UpdateCategoryRequest updateModel);
        bool Delete(int id);
        bool SoftDelete(int id);
    }
}
