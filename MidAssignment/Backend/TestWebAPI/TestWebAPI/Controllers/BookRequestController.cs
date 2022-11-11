using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOs.BookRequest;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        public IBookRequestService _bookRequestService;

        public BookRequestController(IBookRequestService bookRequestService)
        {
            _bookRequestService = bookRequestService;
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, NormalUser")]
        public IActionResult Create([FromBody] CreateBookRequestRequest bookRequestCreateModel)
        {
            if (bookRequestCreateModel == null) return BadRequest();

            try
            {
                var data = _bookRequestService.Create(bookRequestCreateModel);

                return data != null ? Ok(data) : BadRequest("Bad request");
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
                var data = _bookRequestService.GetAll();

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
                var data = _bookRequestService.GetById(id);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Update(int id, [FromBody] ApprovalBookRequestRequest bookRequestUpdateModel)
        {
            if (bookRequestUpdateModel == null) return BadRequest();

            try
            {
                var data = _bookRequestService.Approval(id, bookRequestUpdateModel);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
    }
}
