using ApiProject.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProject.WebUI.ViewComponents.MenuDefaultViewComponents
{
    public class _MenuDefaultProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _MenuDefaultProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7115/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values= await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultProductDto>>(values);
                return View(jsonData);
            }
            return View();
        }
    }
}
