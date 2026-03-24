using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRFrontend.Dtos.BookingDtos;
using System.Text;
using System.Threading.Tasks;

namespace SignalRFrontend.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public class ValidationError
        {
            [JsonProperty("propertyName")]
            public string PropertyName { get; set; }

            [JsonProperty("errorMessage")]
            public string ErrorMessage { get; set; }
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7014/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "null null";

            HttpClient client2 = new HttpClient();
            HttpResponseMessage response = await client2.GetAsync("https://localhost:7014/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7014/api/Booking", stringContent);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();

                try
                {
                    var errors = JsonConvert.DeserializeObject<List<ValidationError>>(errorContent);
                    if(errors != null)
                    {
                        foreach(var error in errors)
                        {
                            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Debug için: Gerçek hatayı görelim
                    ModelState.AddModelError(string.Empty, $"Hata detayı: {errorContent}");
                }

                return View(createBookingDto);
            }
                
        }
    }
}
