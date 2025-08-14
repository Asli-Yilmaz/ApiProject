using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents
{
    public class _AboutDashboardDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
