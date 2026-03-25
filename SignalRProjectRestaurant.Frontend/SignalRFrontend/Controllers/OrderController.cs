using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRFrontend.Controllers
{
    [AllowAnonymous]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderFromBasket(int menuTableId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsync($"https://localhost:7014/api/Order/CreateOrderFromBasket?menuTableId={menuTableId}", null);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok(new { success = true, message = "Sipariş başarıyla oluşturuldu" });
            }

            var errorContent = await responseMessage.Content.ReadAsStringAsync();
            return BadRequest(new { success = false, message = errorContent });
        }
    }
}
