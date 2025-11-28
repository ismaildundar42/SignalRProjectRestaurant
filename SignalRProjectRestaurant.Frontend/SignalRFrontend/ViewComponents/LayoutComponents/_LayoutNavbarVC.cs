using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
