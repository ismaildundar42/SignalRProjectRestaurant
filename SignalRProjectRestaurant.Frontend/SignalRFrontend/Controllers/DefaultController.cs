using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
