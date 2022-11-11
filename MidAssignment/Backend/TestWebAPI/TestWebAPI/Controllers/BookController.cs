using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOs.Book;
using TestWebAPI.DTOs.Pagination;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create([FromBody] CreateBookRequest bookCreateModel)
        {
            if (bookCreateModel == null) return BadRequest();

            try
            {
                var data = _bookService.Create(bookCreateModel);

                return Ok(data);
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, NormalUser")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _bookService.GetAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin, NormalUser")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _bookService.GetById(id);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBookRequest bookUpdateModel)
        {
            if (bookUpdateModel == null) return BadRequest();

            try
            {
                var data = _bookService.Update(id, bookUpdateModel);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _bookService.Delete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }


        [HttpPut("softdelete/{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult SoftDelete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _bookService.SoftDelete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpGet("query")]
        [Authorize(Roles = "SuperAdmin, NormalUser")]
        public ActionResult GetBookQuery(int page, int pageSize, string? name, int? categoryId, SortEnum? sort)
        {
            var queryModel = new PaginationQueryModel
            {
                Page = page,
                PageSize = pageSize,
                Name = name,
                CategoryId = categoryId,
                SortOption = sort
            };

            var result = _bookService.GetPagination(queryModel);

            return Ok(result);
        }
    }
}
