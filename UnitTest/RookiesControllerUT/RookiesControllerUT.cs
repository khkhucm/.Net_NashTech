using ASP.NET_MVC__3.Controllers;
using ASP.NET_MVC__3.Models;
using ASP.NET_MVC__3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
namespace RookiesControllerUT;

public class RookiesControllerUT
{
    private RookiesController _rookiesController;
    private Mock<IServices> _personService;

    [SetUp]
    public void Setup()
    {
        _personService = new Mock<IServices>();
        _rookiesController = new RookiesController(_personService.Object);
    }

    [Test]
    public void AddHttpPost_Valid()
    {
        var mockModel = new CreatePersonRequest
        {
            FirstName = "Dong",
            LastName = "Nguyen Phuong",
            Gender = 1,
            DateOfBirth = new DateTime(2000, 01, 13),
            PhoneNumber = "13214221",
            BirthPlace = "Ha Noi"
        };
        var result = _rookiesController.Create(mockModel);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That((result as RedirectToActionResult).ActionName, Is.EqualTo("Index"));
    }

    [Test]
    public void AddHttpPost_Invalid()
    {
        var key = "ERROR";
        var message = "Model is invalid";

        _rookiesController.ModelState.AddModelError(key, message);

        var model = new CreatePersonRequest();
        var result = _rookiesController.Create();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;
        var modelState = view.ViewData.ModelState;

        Assert.IsFalse(modelState.IsValid);
        Assert.That(modelState.ErrorCount, Is.EqualTo(1));
        modelState.TryGetValue(key, out var value);
        var error = value?.Errors.First().ErrorMessage;
        Assert.That(error, Is.EqualTo(message));
    }

    [Test]
    public void IndexHttpGetAll()
    {
        List<PersonViewModel> _people = new List<PersonViewModel>{
            new PersonViewModel{
                FullName = "Binh Truong Van",
                PhoneNumber = "3241252",
                BirthPlace = "Nam Dinh",
            },

            new PersonViewModel{
                FullName = "Dong Nguyen Phuong",
                PhoneNumber = "1232143",
                BirthPlace = "Ha Noi",
            },
            new PersonViewModel{
                FullName = "Cuong Nguyen Van",
                PhoneNumber = "321241",
                BirthPlace = "Ha Nam",
            },
            new PersonViewModel{
                FullName = "Anh Le Lan",
                PhoneNumber = "4321223",
                BirthPlace = "Thai Binh",
            },
        };

        _personService.Setup(p => p.GetListPerson()).Returns(_people);

        var result = _rookiesController.Index();
        var model = ((ViewResult)result).Model;

        Assert.That(model, Is.AssignableTo<List<PersonViewModel>>());
        Assert.That(model as List<PersonViewModel>, Has.Count.EqualTo(_people.Count));
    }

    [Test]
    public void DetailsHttpGet_InValidIndex()
    {
        _personService.Setup(p => p.GetOnePerson(It.IsAny<int>())).Returns(null as Person);

        var index = 0;
        var result = _rookiesController.Details(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo((result as RedirectToActionResult).ActionName));
    }

    [Test]
    public void DetailsHttpGet_ValidIndex()
    {
        var expectModel = new Person
        {
            FirstName = "Dong",
            LastName = "Nguyen Phuong"
        };

        _personService.Setup(p => p.GetOnePerson(It.IsAny<int>())).Returns(expectModel);

        int index = 0;
        var result = _rookiesController.Details(index) as ViewResult;

        Assert.IsNotNull(result);

        var returnModel = result.Model as PersonDetailsModel;

        Assert.AreEqual(expectModel.FirstName, returnModel.FirstName);
        Assert.AreEqual(expectModel.LastName, returnModel.LastName);
    }

    [Test]
    public void EditHttpGet_InValidIndex()
    {
        _personService.Setup(p => p.GetOnePerson(It.IsAny<int>())).Returns(null as Person);

        var index = 0;
        var result = _rookiesController.Edit(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo((result as RedirectToActionResult).ActionName));
    }

    [Test]
    public void EditHttpGet_ValidIndex()
    {
        var expectModel = new Person
        {
            FirstName = "Dong",
            LastName = "Nguyen Phuong"
        };

        _personService.Setup(p => p.GetOnePerson(It.IsAny<int>())).Returns(expectModel);

        int index = 0;
        var result = _rookiesController.Edit(index) as ViewResult;

        Assert.IsNotNull(result);

        var returnModel = result.ViewData.Model as EditPersonViewModel;

        Assert.AreEqual(expectModel.FirstName, returnModel.FirstName);
        Assert.AreEqual(expectModel.LastName, returnModel.LastName);
    }

    [Test]
    public void UpdateHttpPost()
    {
        var mockModel = new EditPersonViewModel
        {
            FirstName = "Dong",
            LastName = "Nguyen Phuong",
            PhoneNumber = "12382112",
            BirthPlace = "Ha Noi"
        };
        int index = 0;
        var result = _rookiesController.Update(index, mockModel);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
    }

    [Test]
    public void DeleteHttpPost_InValidIndex()
    {
        _personService.Setup(p => p.DeletePerson(It.IsAny<int>())).Returns(null as Person);

        int index = 0;
        var result = _rookiesController.Delete(index);

        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void DeleteHttpPost_ValidIndex()
    {
        var expectModel = new Person
        {
            FirstName = "Dong",
            LastName = "Nguyen Phuong",
            Gender = 1,
            DateOfBirth = new DateTime(2000, 01, 13),
            PhoneNumber = "322123",
            BirthPlace = "Nam Dinh",
            IsGraduated = true
        };

        _personService.Setup(p => p.DeletePerson(It.IsAny<int>())).Returns(expectModel);

        int index = 0;
        var result = _rookiesController.Delete(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo((result as RedirectToActionResult).ActionName));
    }

    [Test]
    public void DeleteAndRedirectToResultView_InValidIndex()
    {
        _personService.Setup(p => p.DeletePerson(It.IsAny<int>())).Returns(null as Person);

        int index = 0;
        var result = _rookiesController.DeleteAndRedirectToResultView(index);

        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public void DeleteAndRedirectToResultView_ValidIndex()
    {
        var httpContext = new Mock<HttpContext>();
        var session = new Mock<ISession>();

        httpContext.Setup(c => c.Session).Returns(session.Object);
        _rookiesController.ControllerContext.HttpContext = httpContext.Object;

        var expectModel = new Person
        {
            FirstName = "Dong",
            LastName = "Nguyen Phuong",
            Gender = 1,
            DateOfBirth = new DateTime(2000, 01, 13),
            PhoneNumber = "322123",
            BirthPlace = "Nam Dinh",
            IsGraduated = true
        };

        _personService.Setup(p => p.DeletePerson(It.IsAny<int>())).Returns(expectModel);

        int index = 0;
        var result = _rookiesController.DeleteAndRedirectToResultView(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("DeleteResult", Is.EqualTo((result as RedirectToActionResult).ActionName));
    }
}