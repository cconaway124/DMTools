using Microsoft.AspNetCore.Mvc;

namespace DMTools.MVC.Controllers
{
    public class StatBlockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
