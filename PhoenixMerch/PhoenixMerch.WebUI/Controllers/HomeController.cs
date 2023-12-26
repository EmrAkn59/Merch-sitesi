using Microsoft.AspNetCore.Mvc;

namespace PhoenixMerch.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
    }
}
