using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.LayoutComponents
{
    public class _LayoutScriptVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
