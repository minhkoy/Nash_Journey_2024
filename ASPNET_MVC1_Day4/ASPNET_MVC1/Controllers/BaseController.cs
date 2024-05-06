using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MVC1.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
