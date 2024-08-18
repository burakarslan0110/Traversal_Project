using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAbout1Service _about1Service;

        public AboutController(IAbout1Service about1Service)
        {
            _about1Service = about1Service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _about1Service.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About1 p)
        {
            _about1Service.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
