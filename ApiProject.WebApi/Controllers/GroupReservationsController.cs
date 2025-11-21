using ApiProject.WebApi.Context;
using ApiProject.WebApi.Dtos.GroupReservationDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public GroupReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateGroupReservation(CreateGroupReservationDto createGroupReservationDto)
        {
            var value = _mapper.Map<GroupReservation>(createGroupReservationDto);
            _context.GroupReservations.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı.");
        }
        [HttpGet]
        public IActionResult ListGroupReservation()
        {
            var values = _context.GroupReservations.ToList();
            return Ok(values);
        }
        [HttpDelete]
        public IActionResult DeleteGroupReservation(int id)
        {
            var value = _context.GroupReservations.Find(id);
            _context.GroupReservations.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }
        [HttpGet("GetGroupReservation")]
        public IActionResult GetGroupReservation(int id)
        {
            var value = _context.GroupReservations.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateGroupReservation(UpdateGroupReservationDto updateGroupReservationDto)
        {
            var value = _mapper.Map<GroupReservation>(updateGroupReservationDto);
            _context.GroupReservations.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı.");

        }
    }
}
