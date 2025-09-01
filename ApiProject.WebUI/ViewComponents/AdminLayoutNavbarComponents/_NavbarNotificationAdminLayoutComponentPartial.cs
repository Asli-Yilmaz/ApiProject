using ApiProject.WebUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiProject.WebUI.ViewComponents.AdminLayoutNavbarComponents
{
    public class _NavbarNotificationAdminLayoutComponentPartial:ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;
        public _NavbarNotificationAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
                _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7115/api/Notifications");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(values);
                return View(jsonData);
            }
            return View();

        }
    }
}
