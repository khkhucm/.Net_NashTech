using Assignment01.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }


        [HttpPost("/newTask")]
        public IActionResult CreateNewTask([FromBody] NewTaskRequestModel requestModel)
        {
            if (string.IsNullOrWhiteSpace(requestModel.Title))
            {
                return BadRequest("No title");
            }

            requestModel.Title = requestModel.Title.Trim();
            if (requestModel.Title.Length < 5)
            {
                return BadRequest("Minium length must be 5 charactors");
            }
            try
            {
                var newID = requestModel.Id;
                return Ok(newID);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bad request");
            }
        }
    }
}