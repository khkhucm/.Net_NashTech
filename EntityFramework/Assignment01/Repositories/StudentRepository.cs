using Assignment01.Models;
using Assignment01.Repositories.Interfaces;

namespace Assignment01.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {
        }
    }
}