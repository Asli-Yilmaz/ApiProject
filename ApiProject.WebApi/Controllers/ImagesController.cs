using ApiProject.WebApi.Context;
using ApiProject.WebApi.Dtos.ImageDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //dependency injection için constract methodlarının  registerationu yapılmalı 
        //bu da program.cs dosyasına : builder.Services.AddDbContext<ApiContext>(); satırı eklenir.

        [HttpPost]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
            //_context.Images.Add(Image);
            //_context.SaveChanges();
            var value = _mapper.Map<Image>(createImageDto);
            _context.Images.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı.");
        }
        [HttpGet]
        public IActionResult ListImage()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            _context.Images.Remove(value);
            _context.SaveChanges();
            return Ok("silme işlemi başarılı.");
        }
        //bir controller içinde aynı attribute türünü birden fazla kullanamazsın hata verir bu yüzden bir ad(root) verilir
        //[HttpGet] ->böyle olsaydı hata alınırdı
        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {

            //_context.Images.Update(Image);
            //_context.SaveChanges();
            var value = _mapper.Map<Image>(updateImageDto);
            _context.Images.Update(value);
            _context.SaveChanges();
            return Ok("güncelleme işlemi başarılı.");

        }
    }
}
