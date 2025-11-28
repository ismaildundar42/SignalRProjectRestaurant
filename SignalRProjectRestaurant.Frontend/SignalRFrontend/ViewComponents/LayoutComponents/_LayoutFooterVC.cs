using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.LayoutComponents
{
    public class _LayoutFooterVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
