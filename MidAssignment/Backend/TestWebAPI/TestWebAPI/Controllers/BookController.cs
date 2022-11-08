using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOs.Book;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBookRequest bookUpdateMode)
        {
            if (bookUpdateMode == null) return BadRequest();

            try
            {
                var data = _bookService.Update(id, bookUpdateMode);

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
                var isSucceeded = _bookService.Delete(id);

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
                var isSucceeded = _bookService.SoftDelete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
    }
}
