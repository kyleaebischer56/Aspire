using Microsoft.AspNetCore.Mvc;

namespace Aspire.Controllers
{
    public class DirectorController : Controller
    {
        public IActionResult UnderConstruction()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}