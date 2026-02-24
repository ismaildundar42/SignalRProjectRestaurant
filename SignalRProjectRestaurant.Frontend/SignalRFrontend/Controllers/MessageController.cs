using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
