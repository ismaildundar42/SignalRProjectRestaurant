using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.Controllers
{
    public class UiLayoutController : Controller
    {
        public IActionResult _UiLayout()
        {
            return View();
        }
    }
}
