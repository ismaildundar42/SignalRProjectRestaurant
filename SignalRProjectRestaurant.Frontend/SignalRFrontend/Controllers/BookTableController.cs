using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class BookTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
