using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRFrontend.Dtos.CategoryDtos;

namespace SignalRFrontend.ViewComponents.MenuComponents
{
    public class _MenuCategoryFiterVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryFiterVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7014/api/Category");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
