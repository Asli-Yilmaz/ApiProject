using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryList()
        {
            return View();
        }
    }
}
