using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRFrontend.Dtos.RapidApiDtos;

namespace SignalRFrontend.Controllers
{
    [AllowAnonymous]
    public class FoodRapidApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=57&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "4b780e4365msh051c17373b7a5ecp178b08jsn3aeb1d9a94cc" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultTastyApiDto>>(body);
                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;
                return View(values.ToList());
            }
        }
    }
}
