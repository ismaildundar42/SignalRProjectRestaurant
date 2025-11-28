using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
