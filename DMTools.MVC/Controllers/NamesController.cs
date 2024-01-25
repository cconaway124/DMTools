using Microsoft.AspNetCore.Mvc;

namespace DMTools.MVC.Controllers
{
    public class NamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
