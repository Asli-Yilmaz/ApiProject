using ApiProject.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProject.WebUI.ViewComponents.MenuDefaultViewComponents
{
    public class _MenuDefaultCategoryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _MenuDefaultCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clinet = _httpClientFactory.CreateClient();
            var responseMessage = await clinet.GetAsync("https://localhost:7115/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
