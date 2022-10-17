using ASP.NET_MVC__3.Models;

namespace ASP.NET_MVC__3.DataAccess
{
    public class StaticPersonDataAccess : IDataAccess
    {
        private static List<Person> _people = new List<Person>{
            new Person{
                    FirstName = "Binh",
                    LastName = "Truong Van",
                    Gender = 1,
                    DateOfBirth = new DateTime(1996,2,10),
                    PhoneNumber = "3241252",
                    BirthPlace = "Nam Dinh",
                    IsGraduated = true
                },

                new Person{
                    FirstName = "Dong",
                    LastName = "Nguyen Phuong",
                    Gender = 1,
                    DateOfBirth = new DateTime(2000, 1, 13),
                    PhoneNumber ="123456",
                    BirthPlace = "Ha Noi",
                    IsGraduated = true
                },
                 new Person{
                    FirstName = "Cuong",
                    LastName = "Nguyen Van",
                    Gender = 1,
                    DateOfBirth = new DateTime(1999,5,9),
                    PhoneNumber = "256789",
                    BirthPlace = "Binh Duong",
                    IsGraduated = false
                },
                 new Person{
                    FirstName = "Anh",
                    LastName = "Le Lan",
                    Gender = 2,
                    DateOfBirth = new DateTime(2001,1,20),
                    PhoneNumber = "328120",
                    BirthPlace = "Nghe An",
                    IsGraduated = true
                },
                 new Person{
                    FirstName = "Thuy",
                    LastName = "Nguyen Phuong",
                    Gender = 2,
                    DateOfBirth = new DateTime(2002, 5, 10),
                    PhoneNumber = "123462",
                    BirthPlace = "Gia Lai",
                    IsGraduated = false
                },
        };

        public List<Person> Persons
        {
            get => _people;
            set
            {
                _people = value;
            }
        }

        public List<Person> GetAllPerson()
        {
            return Persons;
        }

        public void AddPerson(Person person)
        {
            Persons.Add(person);
        }

        public void UpdatePerson(int index, Person person)
        {
            Persons[index] = person;
        }

        public void DeletePerson(int index)
        {
            Persons.RemoveAt(index);
        }
    }
}