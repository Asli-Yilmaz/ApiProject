using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.DashboardWidgetsComponents
{
    public class _DashboardWidgetsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
