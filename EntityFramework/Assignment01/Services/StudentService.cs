using Assignment01.DTOs;
using Assignment01.Models;
using Assignment01.Repositories.Interfaces;
using Assignment01.Services.Interfaces;

namespace Assignment01.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAll()
        {
            var viewModels = _studentRepository.GetAll(x => true);

            return viewModels;
        }

        public AddStudentResponse? GetById(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id);
            AddStudentResponse studentResponse = new AddStudentResponse{
                Id = student.Id,
                FirstName = student.FirstName
            };

            return studentResponse;
        }
        public AddStudentResponse Create(AddStudentRequest createModel)
        {
            var createStudent = new Student
            {
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                City = createModel.City,
                State = createModel.State
            };

            var student = _studentRepository.Create(createStudent);

            _studentRepository.SaveChanges();

            return new AddStudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName
            };
        }

        public AddStudentResponse? Update(int id, AddStudentRequest updateModel)
        {
            var updateStudent = _studentRepository.Get(x => x.Id == id);

            updateStudent.FirstName = updateModel.FirstName;
            updateStudent.LastName = updateModel.LastName;
            updateStudent.City = updateModel.City;
            updateStudent.State = updateModel.State;

            var student = _studentRepository.Update(updateStudent);
            
            _studentRepository.SaveChanges();

             return new AddStudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName
            };
        }

        public AddStudentResponse? Delete(int id){
            var deleteStudent = _studentRepository.Get(x => x.Id == id);
            var student = _studentRepository.Delete(deleteStudent);

            _studentRepository.SaveChanges();

                return new AddStudentResponse
            {
                Id = deleteStudent.Id,
                FirstName = deleteStudent.FirstName
            };
        }
    }
}