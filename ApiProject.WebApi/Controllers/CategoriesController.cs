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
        //dependency injection için constract methodlarının  registerationu yapılmalı 
        //bu da program.cs dosyasına : builder.Services.AddDbContext<ApiContext>(); satırı eklenir.

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Ekleme İşlemi Başarılı.");
        }
        [HttpGet]
        public IActionResult ListCategory() {
            var values= _context.Categories.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı.");
        }
        //bir controller içinde aynı attribute türünü birden fazla kullanamazsın hata verir bu yüzden bir ad(root) verilir
        //[HttpGet] ->böyle olsaydı hata alınırdı
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) {
            var value = _context.Categories.Find(id);
            return Ok(value);  
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category) {

            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı.");

        }
    }
}
