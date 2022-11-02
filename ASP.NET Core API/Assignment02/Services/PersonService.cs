using Assignment02.Models;
using Assignment02.Services.Interfaces;
using Assignment02.Utils;

namespace Assignment02.Services
{
    public class PersonService : IPersonService
    {
        private static readonly List<PersonModel> _peopleList = new List<PersonModel> {
            new PersonModel("Dong", "Nguyen", new DateTime(2000, 01, 13), "Male", "Ha Noi"),
            new PersonModel("Hang", "Le", new DateTime(2003, 11, 01), "Female", "Thanh Hoa"),
            new PersonModel("Anh", "Chu", new DateTime(2005, 01, 10), "Female", "Ha Noi"),
            new PersonModel("Cuc", "Nguyen", new DateTime(2005, 07, 11), "Female", "Ha Nam"),
            new PersonModel("Long", "Hoang", new DateTime(1995, 10, 26), "Male", "Vinh Phuc"),
            new PersonModel("Hieu", "Nguyen", new DateTime(2005, 09, 14), "Male", "Ha Nam"),
            new PersonModel("Thao", "Vu", new DateTime(2000, 06, 24), "Female", "Yen Bai"),
            new PersonModel("Dung", "Ngo", new DateTime(1999, 11, 15), "Female", "Lam Dong"),
            new PersonModel("Anh", "Le", new DateTime(2000, 03, 16), "Male", "Bac Giang"),
            new PersonModel("Hoa", "La", new DateTime(1993, 03, 24), "Female", "Nam Dinh"),
        };

        public PersonModel? Create(PersonCreateModel createModel)
        {
            var newPerson = new PersonModel
            (
                createModel.FirstName,
                createModel.LastName,
                createModel.DateOfBirth,
                createModel.Gender,
                createModel.BirthPlace
            );
            _peopleList.Add(newPerson);

            return newPerson;
        }

        public bool Delete(Guid id)
        {
            var person = GetOne(id);

            return _peopleList.Remove(person);
        }

        public IEnumerable<PersonModel> GetAll(string? fullName, string? gender, string? birthPlace, int page)
        {
            var filterList = _peopleList.AsQueryable();

            if (!string.IsNullOrEmpty(fullName))
            {
                filterList = filterList.Where(person => person.FullName.Trim().ToLower() == fullName.Trim().ToLower());
            }

            if (!string.IsNullOrEmpty(gender))
            {
                string queryGender = "";

                if (string.Equals("male", gender.Trim().ToLower()))
                {
                    queryGender = "Male";
                }
                else if (string.Equals("female", gender.Trim().ToLower()))
                {
                    queryGender = "Female";
                }

                filterList = filterList.Where(person => person.Gender == queryGender);
            }

            if (!string.IsNullOrEmpty(birthPlace))
            {
                filterList = filterList.Where(person => person.BirthPlace.Trim().ToLower() == birthPlace.Trim().ToLower());
            }

            return filterList.Skip((page - 1) * PagingUtil.PageSize)
                             .Take(PagingUtil.PageSize)
                             .ToList();
        }

        public PersonModel? GetOne(Guid id)
        {
            var person = _peopleList.FirstOrDefault(p => p.Id == id);

            return person;
        }

        public PersonModel? Update(Guid id, PersonUpdateModel updateModel)
        {
            var person = GetOne(id);

            if (person != null)
            {
                person.FirstName = updateModel.FirstName;
                person.LastName = updateModel.LastName;
                person.DateOfBirth = updateModel.DateOfBirth;
                person.Gender = updateModel.Gender;
                person.BirthPlace = updateModel.BirthPlace;

                return person;
            }

            return null;
        }
    }
}
