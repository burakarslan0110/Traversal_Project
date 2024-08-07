using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace TraversalPresentationLayer.Controllers
{
    public class TCMBKurController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.X = "1";
            return View();
        }
    }
}
