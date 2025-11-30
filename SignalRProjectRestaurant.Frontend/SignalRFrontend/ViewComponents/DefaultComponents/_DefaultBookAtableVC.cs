using Microsoft.AspNetCore.Mvc;

namespace SignalRFrontend.ViewComponents.DefaultComponents
{
    public class _DefaultBookAtableVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
