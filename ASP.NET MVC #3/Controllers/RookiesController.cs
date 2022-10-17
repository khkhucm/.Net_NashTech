using Microsoft.AspNetCore.Mvc;
using ASP.NET_MVC__3.Services;

namespace ASP.NET_MVC__3.Controllers
{
    public class RookiesController:Controller
    {
        private readonly ILogger<RookiesController> _logger;

        private readonly IServices _service;

        public RookiesController(ILogger<RookiesController> logger, IServices service)
        {
            _logger = logger;
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
            if (index >= 0 && index < _service.GetListPerson().Count)
            {
                var member = _service.GetOnePerson(index);
                var model = new PersonDetailsModel
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Gender = member.Gender,
                    DateOfBirth = member.DateOfBirth,
                    PhoneNumber = member.PhoneNumber,
                    BirthPlace = member.BirthPlace
                };

                ViewData["Index"] = index;

                return View(model);
            }

            return View();
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int index)
        {
            if (index >= 0 && index < _service.GetListEdit().Count)
            {
                var member = _service.GetListEdit()[index];
                var model = new EditPersonViewModel
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    PhoneNumber = member.PhoneNumber,
                    BirthPlace = member.BirthPlace
                };

                ViewData["Index"] = index;

                return View(model);
            }

            return View();
        }

        [HttpPost("Update")]
        public IActionResult Update(int index, EditPersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (index >= 0 && index < _service.GetListEdit().Count)
            {
                _service.UpdatePerson(index, model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < _service.GetListPerson().Count)
            {
                _service.DeletePerson(index);
            }

            return RedirectToAction("Index");
        }

        [HttpPost("DeleteAndRedirectToResultView")]
        public IActionResult DeleteAndRedirectToResultView(int index)
        {
            if (index >= 0 && index < _service.GetListPerson().Count)
            {
                HttpContext.Session.SetString("DeleteNameMember", _service.GetOnePerson(index).FullName);
                _service.DeletePerson(index);
            }

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