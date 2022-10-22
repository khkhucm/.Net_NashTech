using Assignment02.DTOs.Category;
using Assignment02.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public AddCategoryResponse? Add([FromBody] AddCategoryRequest addModel)
        {
            return _categoryService.Add(addModel);
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel>? GetAll()
        {
            try
            {
                var categories = _categoryService.GetAll();

                return categories;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public CategoryViewModel? Get(int id)
        {
            try
            {
                var categories = _categoryService.GetById(id);

                return categories;
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public UpdateCategoryResponse Update(int id, [FromBody] UpdateCategoryRequest updateModel)
        {
            try
            {
                var updatedCategory = _categoryService.Update(id, updateModel);

                return updatedCategory!;
            }
            catch
            {
                return null!;
            }
        }

        [HttpDelete("{id}")]
        public CategoryViewModel Delete(int id)
        {
            try
            {
                var deletedProduct = _categoryService.Delete(id);

                return deletedProduct!;
            }
            catch
            {
                return null!;
            }
        }
    }
}