using ASP.NET_MVC__3.DataAccess;

namespace ASP.NET_MVC__3.Services
{
    public interface IServices
    {
         List<PersonViewModel> GetListPerson();
        Person GetOnePerson(int index);
        void AddPerson(CreatePersonRequest request);
        List<EditPersonViewModel> GetListEdit();
        void UpdatePerson(int index, EditPersonViewModel model);
        void DeletePerson(int index);
    }
}