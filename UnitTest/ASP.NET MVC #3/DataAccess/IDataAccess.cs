using ASP.NET_MVC__3.Models;
namespace ASP.NET_MVC__3.DataAccess
{
    public interface IDataAccess
    {
        List<Person> GetAllPerson();
        void AddPerson(Person Person);
        void UpdatePerson(int index, Person Person);
        Person DeletePerson(int index);
    }
}