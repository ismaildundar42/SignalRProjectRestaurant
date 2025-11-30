using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.UiLayoutComponents
{
    public class _UiLayoutNavbarVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
