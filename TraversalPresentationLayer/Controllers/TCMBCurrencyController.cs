using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;
using TraversalPresentationLayer.Models;

namespace TraversalPresentationLayer.Controllers
{
    [AllowAnonymous]
    public class TCMBCurrencyController : Controller
    {
        // Döviz kurlarını çeken metod

        public async Task<List<TCMBCurrencyModel>> GetExchangeRatesFromTcmb()
        {
            var currencies = new List<TCMBCurrencyModel>();
            var url = "https://www.tcmb.gov.tr/kurlar/today.xml";

            // HttpClient kullanarak XML verisini çekiyoruz
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);

                // XML verisini parse ediyoruz
                var doc = XDocument.Parse(response);

                // Tüm Currency elementlerini bulup listeye ekliyoruz
                foreach (var element in doc.Descendants("Currency"))
                {
                    var currency = new TCMBCurrencyModel()
                    {
                        DovizCinsi = element.Element("Isim").Value,
                        SatisKuru = element.Element("ForexSelling").Value
                    };

                    currencies.Add(currency);
                }
            }

            return currencies;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Döviz kurlarını alıyoruz
            var exchangeRates = await GetExchangeRatesFromTcmb();

            // Veriyi View'e gönderiyoruz
            return View(exchangeRates);
        }
    }
}
