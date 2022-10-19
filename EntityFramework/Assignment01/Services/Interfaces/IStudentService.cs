using Assignment01.DTOs;
using Assignment01.Models;

namespace Assignment01.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        AddStudentResponse? GetById(int id);
        AddStudentResponse Create(AddStudentRequest createModel);
        AddStudentResponse? Update(int id, AddStudentRequest updateModel);

    }
}