using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiProject.WebUI.ViewComponents.DashboardWidgetsComponents
{
    public class _DashboardWidgetsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardWidgetsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7115/api/Reservations/GetTotalReservationCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData1;
            ViewBag.r1 = GetRandomValue(1, 35);
            
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7115/api/Reservations/GetTotalCustomerCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData2;
            ViewBag.r2 = GetRandomValue(1, 35);

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7115/api/Reservations/GetPendingReservations");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonData3;
            ViewBag.r3 = GetRandomValue(1, 35);

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7115/api/Reservations/GetApprovedReservations");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsonData4;
            ViewBag.r4 = GetRandomValue(1, 35);



            return View();
        }
        public int GetRandomValue(int min,int max)
        {
            Random rnd = new Random();
            int randomValue = rnd.Next(min, max);
            return randomValue; 
        }
    }
}
