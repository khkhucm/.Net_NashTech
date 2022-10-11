using Microsoft.AspNetCore.Mvc;
using ASP.NET_MVC__2.Models;

namespace ASP.NET_Core__2.Controllers
{
    public class RookiesController : Controller
    {
        public static List<PersonModel> people = new List<PersonModel>{
            new PersonModel{
                    FirstName = "Binh",
                    LastName = "Truong Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1996,2,10),
                    PhoneNumber = "3241252",
                    BirthPlace = "Nam Dinh",
                    IsGraduated = true
                },

                new PersonModel{
                    FirstName = "Dong",
                    LastName = "Nguyen Phuong",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000, 1, 13),
                    PhoneNumber ="123456",
                    BirthPlace = "Ha Noi",
                    IsGraduated = true
                },
                 new PersonModel{
                    FirstName = "Cuong",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999,5,9),
                    PhoneNumber = "256789",
                    BirthPlace = "Binh Duong",
                    IsGraduated = false
                },
                 new PersonModel{
                    FirstName = "Anh",
                    LastName = "Le Lan",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2001,1,20),
                    PhoneNumber = "328120",
                    BirthPlace = "Nghe An",
                    IsGraduated = true
                },
                 new PersonModel{
                    FirstName = "Thuy",
                    LastName = "Nguyen Phuong",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2002, 5, 10),
                    PhoneNumber = "123462",
                    BirthPlace = "Gia Lai",
                    IsGraduated = false
                },
        };
        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonCreateModel model)
        {
            if (ModelState.IsValid){
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                BirthPlace = model.BirthPlace,
                PhoneNumber = model.PhoneNumber,
                IsGraduated = false,
            };
            people.Add(person);
            foreach (var i in people)
            {
                Console.WriteLine(i.FirstName);
            }

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}