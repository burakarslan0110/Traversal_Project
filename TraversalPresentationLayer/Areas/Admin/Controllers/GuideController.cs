using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        GuideManager _guideManager = new GuideManager(new EFGuideDal());
        public IActionResult Index()
        {
            var values = _guideManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            AdminGuideValidator validationRules = new AdminGuideValidator();
            ValidationResult validationResult = validationRules.Validate(guide);
            if(validationResult.IsValid)
            {
                _guideManager.TInsert(guide);
                return RedirectToAction("Guide", "Admin");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideManager.TUpdate(guide);
            return RedirectToAction("Guide", "Admin");
        }
        public IActionResult ChangeToTrue(int id)
        {
            _guideManager.TChangeToTrueByGuide(id);
            return RedirectToAction("Guide", "Admin");
        }
        public IActionResult ChangeToFalse(int id)
        {
            _guideManager.TChangeToFalseByGuide(id);
            return RedirectToAction("Guide", "Admin");
        }
        public IActionResult DeleteGuide(int id)
        {
            var values = _guideManager.TGetByID(id);
            _guideManager.TDelete(values);
            return RedirectToAction("Guide", "Admin");
        }

    }
}
