using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_MVC.Services;
using CsvHelper;
using System.Globalization;
using ASP.NET_MVC.DataAccess;

namespace ASP.NET_MVC.Controllers;
[Route("Nashtech/Rookies")]
public class RookiesController : Controller
{
    private PersonService _peopleService;

    private readonly ILogger<RookiesController> _logger;

    public RookiesController(ILogger<RookiesController> logger)
    {
        _peopleService = new PersonService();
        _logger = logger;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        return Json(_peopleService.GetMembers());
    }

    [Route("GetMaleMembers")]
    public IActionResult GetMaleMembers()
    {
        var data = _peopleService.GetMembers().Where(p => p.Gender == "Male");

        return Json(data);
    }

    [Route("OldestMember")]
    public IActionResult GetOldestMember()
    {
        var maxAge = _peopleService.GetMembers().Max(p => p.Age);
        var oldest = _peopleService.GetMembers().FirstOrDefault(p => p.Age == maxAge);

        return Json(oldest);
    }

    [Route("GetFullName")]
    public IActionResult GetFullName()
    {
        var fullNames = _peopleService.GetMembers().Select(p => p.FullName);

        return Json(fullNames);
    }

    [Route("GetMemberByBirthYear")]
    public IActionResult GetMemberByBirthYear(int year, string compareType)
    {
        switch (compareType)
        {
            case "equals":
                return Json(_peopleService.GetMembers().Where(p => p.DateOfBirth.Year == year));
            case "greaterThan":
                return Json(_peopleService.GetMembers().Where(p => p.DateOfBirth.Year > year));
            case "lessThan":
                return Json(_peopleService.GetMembers().Where(p => p.DateOfBirth.Year < year));
            default:
                return Json(null);
        }
    }

    [Route("GetMemberBornIn2000")]
    public IActionResult GetMemberBornIn2000()
    {
        return RedirectToAction("GetMemberByBirthYear", new { year = 2000, compareType = "equals" });
    }

    [Route("GetMemberBornAfter2000")]
    public IActionResult GetMemberBornAfter2000()
    {
        return RedirectToAction("GetMemberByBirthYear", new { year = 2000, compareType = "greaterThan" });
    }

    [Route("GetMemberBornBefore2000")]
    public IActionResult GetMemberBornBefore2000()
    {
        return RedirectToAction("GetMemberByBirthYear", new { year = 2000, compareType = "lessThan" });
    }

    [Route("ExportDataToCsv")]
    public FileStreamResult ExportDataToCsv()
    {
        var result = WriteCsvToMemory(_peopleService.GetMembers());
        var memoryStream = new MemoryStream(result);

        return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "result.csv" };
    }

    public byte[] WriteCsvToMemory(IEnumerable<Person> _people)
    {
        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture))
        {
            csvWriter.WriteRecords(_people);
            streamWriter.Flush();
            return memoryStream.ToArray();
        }
    }

}
