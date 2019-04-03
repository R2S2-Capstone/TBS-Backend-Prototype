using Microsoft.AspNetCore.Mvc;

namespace TBS_Backend_Prototype.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
