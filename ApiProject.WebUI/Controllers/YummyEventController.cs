using ApiProject.WebUI.Dtos.YummyEventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProject.WebUI.Controllers
{
    public class YummyEventController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public YummyEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> YummyEventList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7115/api/YummyEvents");
            if (responseMessage.IsSuccessStatusCode)
            {
                var value = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultYummyEventDto>>(value);
                return View(jsonData);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateYummyEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateYummyEvent(CreateYummyEventDto createYummyEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createYummyEventDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7115/api/YummyEvents", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("YummyEventList");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7115/api/YummyEvents/GetYummyEvent?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetYummyEventByIdDto>(jsonData);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateYummyEvent(UpdateYummyEventDto updateYummyEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateYummyEventDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7115/api/YummyEvents", stringContent);
            return RedirectToAction("YummyEventList");
        }
        public async Task<IActionResult> DeleteYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7115/api/YummyEvents?id=" + id);
            return RedirectToAction("YummyEventList");
        }
    }
}
