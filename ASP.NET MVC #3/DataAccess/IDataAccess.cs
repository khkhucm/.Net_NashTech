namespace ASP.NET_MVC__3.DataAccess
{
    public interface IDataAccess
    {
         List<Person> GetAllPerson();
        void AddPerson(Person Person);
        void UpdatePerson(int index, Person Person);
        void DeletePerson(int index);
    }
}