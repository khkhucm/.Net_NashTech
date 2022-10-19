using Microsoft.EntityFrameworkCore;

namespace Assignment01.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Student> Students {get;set;} = null!;
    }
}