using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiProject.WebUI.Controllers
{
    public class AIController : Controller
    {
        public IActionResult CreateRecipeWithOpenAi()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipeWithOpenAi(string prompt)
        {
            var apiKey = "openai-api-key";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir yemek tarifleri asistanısın." },
                    new { role = "user", content = prompt }
                }
            };

            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<OpenAIResponse>(responseBody);
                ViewBag.recipe = result.choices[0].message.content;
            }
            else
            {
                ViewBag.recipe = $"Bir hata oluştu: {response.StatusCode}, detay: {responseBody}";
            }

            return View();
        }

        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }

        public class Choice
        {
            public Message message { get; set; }
        }
        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}
