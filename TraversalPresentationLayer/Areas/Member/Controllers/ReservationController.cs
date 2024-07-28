using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EFDestinationDal());

        ReservationManager _reservationManager = new ReservationManager(new EFReservationDal());
        public IActionResult MyCurrentReservation()
        {
           return View();  
        }
        public IActionResult MyOldReservation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values =(from x in _destinationManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.City,
                                              Value = x.DestinationID.ToString()
                                          }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserID = 1;
            p.Status = "Onay Bekliyor";
            _reservationManager.TInsert(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
