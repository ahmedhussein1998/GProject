using Microsoft.AspNetCore.Mvc;

namespace Gproject.UI.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
