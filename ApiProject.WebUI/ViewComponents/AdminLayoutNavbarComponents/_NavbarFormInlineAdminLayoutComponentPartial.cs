using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.ViewComponents.AdminLayoutNavbarComponents
{
    public class _NavbarFormInlineAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
