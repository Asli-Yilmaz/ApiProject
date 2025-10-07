using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        private readonly ApiContext _context;
        public EmployeeTasksController(ApiContext context)
        {
            _context = context;
        }
        //dependency injection için constract methodlarının  registerationu yapılmalı 
        //bu da program.cs dosyasına : builder.Services.AddDbContext<ApiContext>(); satırı eklenir.

        [HttpPost]
        public IActionResult CreateCategory(EmployeeTask EmployeeTask)
        {
            _context.EmployeeTasks.Add(EmployeeTask);
            _context.SaveChanges();
            return Ok("Referans Ekleme İşlemi Başarılı.");
        }
        [HttpGet]
        public IActionResult ListEmployeeTask()
        {
            var values = _context.EmployeeTasks.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.EmployeeTasks.Find(id);
            _context.EmployeeTasks.Remove(value);
            _context.SaveChanges();
            return Ok("Referans silme işlemi başarılı.");
        }
        //bir controller içinde aynı attribute türünü birden fazla kullanamazsın hata verir bu yüzden bir ad(root) verilir
        //[HttpGet] ->böyle olsaydı hata alınırdı
        [HttpGet("GetEmployeeTask")]
        public IActionResult GetEmployeeTask(int id)
        {
            var value = _context.EmployeeTasks.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateEmployeeTask(EmployeeTask EmployeeTask)
        {

            _context.EmployeeTasks.Update(EmployeeTask);
            _context.SaveChanges();
            return Ok("Referans güncelleme işlemi başarılı.");

        }
    }
}
