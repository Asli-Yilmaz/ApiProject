using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ApiProject.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _RightSettingsAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
