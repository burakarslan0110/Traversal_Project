using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            _destinationManager.TInsert(p);
            return RedirectToAction("Destination","Admin");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationManager.TGetByID(id);
            _destinationManager.TDelete(values);
            return RedirectToAction("Destination", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            _destinationManager.TUpdate(p);
            return RedirectToAction("Destination", "Admin");
        }
    }
}
