using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.MenuComponents
{
    public class _MenuNavbarVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
