using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.UiLayoutComponents
{
    public class _UiLayoutHeadVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
