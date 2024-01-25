using Microsoft.AspNetCore.Mvc;

namespace DMTools.MVC.Controllers
{
    public class EncounterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
