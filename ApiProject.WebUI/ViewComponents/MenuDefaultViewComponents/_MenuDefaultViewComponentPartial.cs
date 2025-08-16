using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.MenuDefaultViewComponents
{
    public class _MenuDefaultViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
