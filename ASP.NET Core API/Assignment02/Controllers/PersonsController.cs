using Assignment02.Models;
using Assignment02.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment02.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonsController(IPersonService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonCreateModel personCreateModel)
        {
            if (personCreateModel == null) return BadRequest();

            try
            {
                var data = _service.Create(personCreateModel);

                return Ok(data);
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpGet]
        public IActionResult GetAll(string? firstName, string? gender, string? birthPlace, int page = 1)
        {
            try
            {
                var data = _service.GetAll(firstName, gender, birthPlace, page);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            try
            {
                var data = _service.GetOne(id);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody] PersonUpdateModel personUpdateModel)
        {
            if (personUpdateModel == null) return BadRequest();

            try
            {
                var data = _service.Update(id, personUpdateModel);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var message = "Delete succeeded";
            try
            {
                var isSucceeded = _service.Delete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
    }
}