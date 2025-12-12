using ApiProject.WebUI.Dtos.AISuggestionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; // JObject için gerekli
using System.Net.Http.Headers;
using System.Text;

namespace ApiProjeKampi.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardAIDailyMenuSuggestionComponentPartial : ViewComponent
    {
        
        private const string GEMINI_API_KEY = "";

        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardAIDailyMenuSuggestionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // API KEY KONTROLÜ
            if (string.IsNullOrEmpty(GEMINI_API_KEY) || GEMINI_API_KEY.Length < 10)
            {
                return View(new List<MenuSuggestionDto>());
            }

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string prompt = @"
        4 farklı dünya mutfağından rastgele günlük menü oluştur.
        Cevap SADECE ham JSON formatında olsun. Markdown formatı (```json) veya ek açıklama metni KULLANMA.
        
        İstenen JSON Formatı:
        [
          {
            ""Cuisine"": ""İtalyan Mutfağı"",
            ""CountryCode"": ""IT"",
            ""MenuTitle"": ""Akdeniz Esintisi"",
            ""Items"": [
              { ""Name"": ""Pizza"", ""Description"": ""Margarita"", ""Price"": 100 }
            ]
          }
        ]
    ";

            var body = new
            {
                contents = new[]
                {
            new { parts = new[] { new { text = prompt } } }
        }
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(
                    $"v1beta/models/gemini-2.5-flash:generateContent?key={GEMINI_API_KEY}",
                    content
                );

                if (!response.IsSuccessStatusCode)
                {
                    return View(new List<MenuSuggestionDto>());
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(responseJson);

                if (result["candidates"] == null)
                {
                    return View(new List<MenuSuggestionDto>());
                }

                var aiText = result["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                if (string.IsNullOrEmpty(aiText)) return View(new List<MenuSuggestionDto>());

                // Markdown temizliği
                aiText = aiText.Replace("```json", "").Replace("```", "").Trim();

                var menus = JsonConvert.DeserializeObject<List<MenuSuggestionDto>>(aiText);
                return View(menus);
            }
            catch (Exception)
            {
                return View(new List<MenuSuggestionDto>());
            }
        }
    }
}