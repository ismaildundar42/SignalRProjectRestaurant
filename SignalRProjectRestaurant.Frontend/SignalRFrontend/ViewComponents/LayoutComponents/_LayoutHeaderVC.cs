using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
