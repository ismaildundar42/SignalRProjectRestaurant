using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
