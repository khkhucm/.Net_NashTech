using Assignment01.Models.RequestModels;
using Assignment01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITasksService _service;
        public TasksController(ILogger<TasksController> logger, ITasksService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                var data = _service.GetAll();
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
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] NewTaskRequestModel taskRequestModel)
        {
            //TODO: Validate request model

            try
            {
                var data = _service.AddTask(taskRequestModel);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            try
            {
                var data = _service.DeleteTask(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult EditTask([FromBody] NewTaskRequestModel taskRequestModel)
        {
            // TODO: Validate request model

            try
            {
                var data = _service.EditTask(taskRequestModel);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bad request");
            }
        }

        [HttpPost("add-multitasks")]
        public async Task<IActionResult> AddBulkTasks([FromBody] List<NewTaskRequestModel> tasks)
        {
            //TODO: Validate request model

            try
            {
                await _service.AddBulkTasks(tasks);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bad request");
            }
        }


        [HttpDelete("delete-multitasks")]
        public async Task<IActionResult> DeleteBulkTasks([FromBody] List<Guid> ids)
        {
            //TODO: Validate request model

            try
            {
                await _service.DeleteBulkTasks(ids);
                return Ok(ids);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bad request");
            }
        }
        //public
        // [HttpPost("/newTask")]
        // public IActionResult CreateNewTask([FromBody] NewTaskRequestModel requestModel)
        // {
        //     if (string.IsNullOrWhiteSpace(requestModel.Title))
        //     {
        //         return BadRequest("No title");
        //     }

        //     requestModel.Title = requestModel.Title.Trim();
        //     if (requestModel.Title.Length < 5)
        //     {
        //         return BadRequest("Minium length must be 5 charactors");
        //     }
        //     try
        //     {
        //         var newID = requestModel.Id;
        //         return Ok(newID);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, "Bad request");
        //     }
        // }

        // [HttpPost("v1/bulk")]
        // public IActionResult CreateBulkTask_V1([FromBody] List<NewTaskRequestModel> requestModels)
        // {
        //     //TODO: Validate request model
        //     try
        //     {
        //         _ = CreateMultiTask_V1(requestModels);
        //         return Accepted();
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, "Bad request");
        //     }
        // }
        // [HttpPost("v2/bulk")]
        // public async Task<IActionResult> CreateBulkTask_V2([FromBody] List<NewTaskRequestModel> requestModels)
        // {
        //     //TODO: Validate request model
        //     try
        //     {
        //         await CreateMultiTask_V1(requestModels);
        //         return Ok();
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, "Bad request");
        //     }
        // }

        // [HttpPost("v3/bulk")]
        // public IActionResult CreateBulkTask_V3([FromBody] List<NewTaskRequestModel> requestModels)
        // {
        //     //TODO: Validate request model
        //     try
        //     {
        //         CreateMultiTask_V1(requestModels);
        //         return Ok();
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, "Bad request");
        //     }
        // }

        // private Task CreateMultiTask_V1(List<NewTaskRequestModel> requestModels)
        // {
        //     foreach (var requestModel in requestModels)
        //     {
        //         CreateNewTask_Service(requestModel);
        //     }
        //     //TODO: notify rusultto client: send emails....
        //     _ = SendEmail_V1();
        //     return Task.CompletedTask;
        // }

        // private void CreateNewTask_Service(NewTaskRequestModel requestModel)
        // {
        //     System.Threading.Thread.Sleep(10);
        // }

        // private Task SendEmail_V1()
        // {
        //     return Task.CompletedTask;
        // }

    }
}