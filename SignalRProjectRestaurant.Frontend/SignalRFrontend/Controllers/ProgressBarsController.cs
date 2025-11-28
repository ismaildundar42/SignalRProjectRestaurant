using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class ProgressBarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
