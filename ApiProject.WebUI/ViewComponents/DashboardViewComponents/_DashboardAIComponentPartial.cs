using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardAIComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
