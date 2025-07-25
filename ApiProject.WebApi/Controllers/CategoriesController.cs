using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        //constract methodlarının  registerationu yapılmalı 
        //bu da program.cs dosyasına : builder.Services.AddDbContext<ApiContext>(); satırı eklenir.

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Ekleme İşlemi Başarılı.");
        }
    }
}
