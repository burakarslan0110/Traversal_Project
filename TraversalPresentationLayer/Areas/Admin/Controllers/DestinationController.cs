using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        private readonly IGuideService  _guideService;

        public DestinationController(IDestinationService destinationService, IGuideService guideService)
        {
            _destinationService = destinationService;
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            List<SelectListItem> values = (from x in _guideService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.GuideName,
                                               Value = x.GuideID.ToString()
                                           }).ToList();
            ViewBag.SLG = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            _destinationService.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            List<SelectListItem> values1 = (from x in _guideService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.GuideName,
                                               Value = x.GuideID.ToString()
                                           }).ToList();
            ViewBag.SLG = values1;
            var values = _destinationService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            _destinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
