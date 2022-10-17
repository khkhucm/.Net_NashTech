using ASP.NET_MVC__3.DataAccess;

namespace ASP.NET_MVC__3.Services
{
    public class PersonService : IServices
    {
        private readonly IDataAccess _dataAccess;
        public PersonService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<PersonViewModel> GetListPerson()
        {
            var listApplicationModels = _dataAccess.GetAllPerson();
            var listViewModels = new List<PersonViewModel>();

            foreach (var item in listApplicationModels)
            {
                listViewModels.Add(new PersonViewModel
                {
                    FullName = item.FullName,
                    DateOfBirth = item.DateOfBirth.ToString("dd/MM/yyyy"),
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                    Gender = item.Gender == 1 ? "Male" : item.Gender == 2 ? "Female" : "Other",
                    Age = item.Age,
                });
            }

            return listViewModels;
        }

        public Person GetOnePerson(int index)
        {

            return _dataAccess.GetAllPerson()[index];
        }

        public void AddPerson(CreatePersonRequest request)
        {
            Person member = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                BirthPlace = request.BirthPlace,
                IsGraduated = false
            };

            _dataAccess.AddPerson(member);
        }

        public List<EditPersonViewModel> GetListEdit()
        {
            var listApplicationModels = _dataAccess.GetAllPerson();
            var listViewModels = new List<EditPersonViewModel>();

            foreach (var item in listApplicationModels)
            {
                listViewModels.Add(new EditPersonViewModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                });
            }

            return listViewModels;
        }

        public void UpdatePerson(int index, EditPersonViewModel model)
        {
            var member = _dataAccess.GetAllPerson()[index];

            member.FirstName = model.FirstName;
            member.LastName = model.LastName;
            member.PhoneNumber = model.PhoneNumber;
            member.BirthPlace = model.BirthPlace;

            _dataAccess.UpdatePerson(index, member);
        }

        public void DeletePerson(int index)
        {
            _dataAccess.DeletePerson(index);
        }


    }
}