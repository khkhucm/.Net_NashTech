using Assignment02.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


    }
}