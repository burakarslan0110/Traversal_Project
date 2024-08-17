using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureImagesController : Controller
    {
        private readonly IFeature1Service _feature1Service;

        public FeatureImagesController(IFeature1Service feature1Service)
        {
            _feature1Service = feature1Service;
        }

        public IActionResult Index()
        {
            var values = _feature1Service.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var value = _feature1Service.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditImage(Feature1 p)
        {
            _feature1Service.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
