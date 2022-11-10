using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOs.Category;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryRequest categoryCreateModel)
        {
            if (categoryCreateModel == null) return BadRequest();

            try
            {
                var data = _categoryService.Create(categoryCreateModel);

                return Ok(data);
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _categoryService.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _categoryService.GetById(id);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _categoryService.Delete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("softdelete/{id}")]
        public ActionResult SoftDelete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _categoryService.SoftDelete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCategoryRequest categoryUpdateMode)
        {
            if (categoryUpdateMode == null) return BadRequest();

            try
            {
                var data = _categoryService.Update(id, categoryUpdateMode);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
    }
}
