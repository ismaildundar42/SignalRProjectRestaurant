using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRFrontend.Dtos.BasketDtos;
using SignalRFrontend.Dtos.ProductDtos;
using System.Text;

namespace SignalRFrontend.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            TempData["x"] = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id,int menuTableId)
        {

            if(menuTableId == 0)
            {
                return BadRequest("Menu Table 0 geliyor.");
            }

            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductId = id;
            createBasketDto.MenuTableId = menuTableId;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7014/api/MenuTable/ChangeMenuTableStatusToTrue?id=" + menuTableId);



            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok();
            }
            return Json(createBasketDto);
        }
    }
}
