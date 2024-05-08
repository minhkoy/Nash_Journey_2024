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

        public IActionResult GetListPeople([FromQuery]int? page, [FromQuery]int? pageSize)
        {
            if (!page.HasValue || page < 1)
            {
                page = 1;
            }
            if (!pageSize.HasValue || pageSize < 1)
            {
                pageSize = 10;
            }
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(_personService.GetListPeople(page.Value, pageSize.Value));
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.ID = Guid.NewGuid();
                _personService.Create(person);
                return RedirectToAction(actionName: nameof(GetListPeople));
            }
            else return View();
        }

        public IActionResult Details(Guid id)
        {
            var person = _personService.GetById(id);
            if (person is null)
            {
                return NotFound();
            }
            return View(person);
        }
        public IActionResult Edit(Guid id)
        {
            var person = _personService.GetById(id);
            if (person is null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _personService.Update(person);
            return RedirectToAction(actionName: nameof(GetListPeople));
        }

        public IActionResult Delete(Guid id)
        {
            var person = _personService.GetById(id);
            if (person is null) return NotFound();
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(Person person)
        {
            var deleteResult = _personService.Delete(person.ID);
            if (deleteResult)
            {
                return RedirectToAction(actionName: nameof(DeleteSuccess), 
                    new {notification = $"Person {person.GetFullName()} was removed from the list successfully!"});
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult DeleteSuccess(string notification)
        {
            return View(model: notification);
        }

        /// <summary>
        /// Get people from the list by birth year and comparer. 
        /// A current problem is that the comparer dropdown in the view is not able to modify the query string. It can only be done by 
        /// hard-typing the URL.
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
