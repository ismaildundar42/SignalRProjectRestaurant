using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
