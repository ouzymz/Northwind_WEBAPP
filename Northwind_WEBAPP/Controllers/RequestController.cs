using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind_WEBAPP.DTOs;

namespace Northwind_WEBAPP.Controllers
{
    public class RequestController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RequestController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public async Task<IActionResult> RequestCustormerOrders()
        //{
        //    var customerId = "ALFKI";

        //    List<OrderDTO> olist = new List<OrderDTO>();

        //    var requestUri = "https://localhost:7219/api/Linq/CustomerOrders?Id=" + customerId;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(requestUri);
        //        var response = await client.SendAsync("CustomerOrders");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var readTask = await response.Content.ReadAsStringAsync();
        //            olist = JsonConvert.DeserializeObject<List<OrderDTO>>(readTask);
        //        }
        //    }
        //    return View(olist);
        //}
    }
}
