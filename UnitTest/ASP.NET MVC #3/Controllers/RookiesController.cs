using Microsoft.AspNetCore.Mvc;
using ASP.NET_MVC__3.Services;
using ASP.NET_MVC__3.Models;

namespace ASP.NET_MVC__3.Controllers
{
    public class RookiesController : Controller
    {

        private readonly IServices _service;

        public RookiesController(IServices service)
        {
            _service = service;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View(_service.GetListPerson());
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(CreatePersonRequest request)
        {
            if (ModelState.IsValid)
            {
                _service.AddPerson(request);

                return RedirectToAction("Index");
            }

            return View(request);
        }

        [HttpGet("Details")]
        public IActionResult Details(int index)
        {
            var person = _service.GetOnePerson(index);

            if (person != null)
            {
                var model = new PersonDetailsModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    DateOfBirth = person.DateOfBirth,
                    PhoneNumber = person.PhoneNumber,
                    BirthPlace = person.BirthPlace,
                };
                ViewData["Index"] = index;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int index)
        {
            var person = _service.GetOnePerson(index);

            if (person != null)
            {
                var model = new EditPersonViewModel
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PhoneNumber = person.PhoneNumber,
                    BirthPlace = person.BirthPlace,
                };
                ViewData["Index"] = index;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost("Update")]
        public IActionResult Update(int index, EditPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = _service.GetOnePerson(index);

                if (person != null)
                {
                    _service.UpdatePerson(index, model);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int index)
        {
            var result = _service.DeletePerson(index);
            if (result == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpPost("DeleteAndRedirectToResultView")]
        public IActionResult DeleteAndRedirectToResultView(int index)
        {
            var result = _service.DeletePerson(index);
            if (result == null)
            {
                return NotFound();
            }

            //Store deleted person to session
            HttpContext.Session.SetString("DeletedPersonName", result.FullName);

            return RedirectToAction("DeleteResult");
        }

        [HttpGet("DeleteResult")]
        public IActionResult DeleteResult()
        {
            ViewBag.DeleteNameMember = HttpContext.Session.GetString("DeleteNameMember") ?? "unknown";
            return View();
        }
    }
}