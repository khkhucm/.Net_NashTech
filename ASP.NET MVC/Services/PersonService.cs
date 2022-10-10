using ASP.NET_MVC.DataAccess;

namespace ASP.NET_MVC.Services
{
    public class PersonService
    {
        public List<Person> GetMembers()
        {
            var data = new StaticDataAccess();
            return data.GetPeople();
        }
    }
}