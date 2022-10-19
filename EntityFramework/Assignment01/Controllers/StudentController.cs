using Assignment01.DTOs;
using Assignment01.Models;
using Assignment01.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public AddStudentResponse Add([FromBody] AddStudentRequest addRequest)
        {
            return _studentService.Create(addRequest);
        }

        [HttpGet]
        public IEnumerable<Student>? GetAll()
        {
            try
            {
                var students = _studentService.GetAll();

                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public AddStudentResponse? GetById(int id)
        {
            try
            {
                return _studentService.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public AddStudentResponse Update(int id, [FromBody] AddStudentRequest updateModel)
        {
            try
            {
                var updatedStudent = _studentService.Update(id, updateModel);

                return updatedStudent!;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }
    }
}