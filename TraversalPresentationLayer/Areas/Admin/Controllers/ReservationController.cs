using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _restinationService;
        private readonly IDestinationService _destinationService;

        public ReservationController(IReservationService restinationService, IDestinationService destinationService)
        {
            _restinationService = restinationService;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _restinationService.GetAllReservation();
            return View(values);
        }

        public IActionResult ReservationApprove(int id) 
        {
            _restinationService.ApproveReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult ReservationReject(int id)
        {
            _restinationService.RejectReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult ReservationWaiting(int id)
        {
            _restinationService.WaitingApproveReservation(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            var values = _restinationService.TGetByID(id);
            List<SelectListItem> rdl = (from x in _destinationService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.RDL = rdl;
            return View(values);

        }
        [HttpPost]
        public IActionResult EditReservation(Reservation p)
        {
            p.Status = "Onay Bekliyor";
            _restinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteReservation(int id)
        {
            var values = _restinationService.TGetByID(id);
            _restinationService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
