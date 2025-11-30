using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.UiLayoutComponents
{
    public class _UiLayoutScriptsVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
