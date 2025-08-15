using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;
        public ServicesController(ApiContext context)
        {
            _context = context;
        }
        //dependency injection için constract methodlarının  registerationu yapılmalı 
        //bu da program.cs dosyasına : builder.Services.AddDbContext<ApiContext>(); satırı eklenir.

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet Ekleme İşlemi Başarılı.");
        }
        [HttpGet]
        public IActionResult ListService()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet silme işlemi başarılı.");
        }
        //bir controller içinde aynı attribute türünü birden fazla kullanamazsın hata verir bu yüzden bir ad(root) verilir
        //[HttpGet] ->böyle olsaydı hata alınırdı
        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {

            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Hizmet güncelleme işlemi başarılı.");

        }
    }
}
