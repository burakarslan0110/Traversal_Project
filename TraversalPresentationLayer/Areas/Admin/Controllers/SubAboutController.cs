using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubAboutController : Controller
    {
        private readonly ISubAboutDal _subAboutDal;

        public SubAboutController(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _subAboutDal.GetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(SubAbout p)
        {
            _subAboutDal.Update(p);
            return RedirectToAction("Index");
        }
    }
}
