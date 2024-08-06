using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalPresentationLayer.Models;

namespace TraversalPresentationLayer.Controllers
{

    public class ExchangeRatesAPIController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index() // değişecek
        {
            List<ExchangeRatesViewModel> exchangeRatesViewModels = new List<ExchangeRatesViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "5304a69aacmsh6fc15023f51c452p19bc34jsn7ab26621b258" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeRatesViewModel>(body);
                return View(values.exchange_rates);
            }
        }
    }
}
