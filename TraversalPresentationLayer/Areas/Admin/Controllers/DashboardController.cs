using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class DashboardController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IContactUsService _contactUsService;

        public DashboardController(IReservationService reservationService, IContactUsService contactUsService)
        {
            _reservationService = reservationService;
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            ViewBag.ReservationCount = _reservationService.TGetList().Count;
            ViewBag.ContactUsCount = _contactUsService.TGetList().Count;
            ViewBag.TotalIncome = _reservationService.GetAllReservation().Sum(x => x.Destination.Price);
            return View();
        }
    }
}
