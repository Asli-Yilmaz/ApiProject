using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;
        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }
        //dependency injection için constract methodlarının  registerationu yapılmalı 
        //bu da program.cs dosyasına : builder.Services.AddDbContext<ApiContext>(); satırı eklenir.

        [HttpPost]
        public IActionResult CreateCategory(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Referans Ekleme İşlemi Başarılı.");
        }
        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Referans silme işlemi başarılı.");
        }
        //bir controller içinde aynı attribute türünü birden fazla kullanamazsın hata verir bu yüzden bir ad(root) verilir
        //[HttpGet] ->böyle olsaydı hata alınırdı
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {

            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Referans güncelleme işlemi başarılı.");

        }
    }
}
