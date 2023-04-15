using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Northwind_WEBAPP.DTOs;
using Northwind_WEBAPP.Models;
using System.Diagnostics;

namespace Northwind_WEBAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> RequestCustormerOrders()
        {
            List<OrderDTO> olist = new List<OrderDTO>();

            var customerId = "ALFKI";

            var json = JsonConvert.SerializeObject(customerId, Formatting.Indented);

            HttpContent stringContent = new StringContent(json);


            //var requestUri = "https://localhost:7219/api/Linq/CustomerOrders?Id=" + customerId;
            var requestUri = "https://localhost:7219/api/Linq/CustomerOrders";

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            requestMessage.Content = stringContent;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(requestUri);
                var response = await client.PostAsync(requestUri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var readTask = await response.Content.ReadAsStringAsync();
                    olist = JsonConvert.DeserializeObject<List<OrderDTO>>(readTask);
                }
            }
            return View("RequestCustormerOrders",olist);
        }
    }

}
