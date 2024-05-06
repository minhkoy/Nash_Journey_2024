using ASPNET_MVC.Business.Interfaces;
using ASPNET_MVC.Models;
using ASPNET_MVC.Models.Helpers;
using ASPNET_MVC.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace ASPNET_MVC1.Areas.NashTech.Controllers
{
    [Area("NashTech")]
    public class RookiesController : Controller
    {
        private readonly ILogger<RookiesController> _logger;
        private readonly IPersonService _personService;

        public RookiesController(ILogger<RookiesController> logger,
            IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetMalePeopleAction()
        {
            return View(_personService.GetPeopleByGender(ConstantExtensions.Genders.Male));
        }

        public IActionResult GetOldestPersonByAgeAction()
        {
            return View(_personService.GetOldestPersonByAge());
        }

        public IActionResult GetOldestPersonByDobAction()
        {
            return View(_personService.GetOldestPersonByDob());
        }

        public IActionResult GetPeopleFullNameAction()
        {
            return View(_personService.GetOnlyFullnameList());
        }

        /// <summary>
        /// Get people from the list by birth year and comparer. 
        /// A current problem is that the comparer dropdown in the view is not able to modify the query string. It can only be done by 
        /// hard-fixing the URL.
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public IActionResult GetPeopleByBirthYearAction([FromQuery] string comparer = ConstantExtensions.Comparer.Equal, [FromQuery] int birthYear = 2000)
        {
            //var birthYear = 2000;
            ViewData["Rookie_GetPeopleByBirthYear_Comparer"] = comparer;
            ViewData["Rookie_GetPeopleByBirthYear_BirthYear"] = birthYear;
            return View(_personService.GetPeopleWithBirthYear(comparer, birthYear));
        }

        public IActionResult ExportPeopleListToExcelAction()
        {
            var stream = _personService.ExportPeopleListToExcel();
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }        
    }
}
