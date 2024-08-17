using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values = _testimonialService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            p.Status = true;
            _testimonialService.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial p)
        {
            _testimonialService.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToTrue(int id)
        {
            _testimonialService.TChangeToTrueByTestimonial(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToFalse(int id)
        {
            _testimonialService.TChangeToFalseByTestimonial(id);
            return RedirectToAction("Index");
        }
        
    }
}
