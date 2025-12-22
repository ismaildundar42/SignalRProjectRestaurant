using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class BookATableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
