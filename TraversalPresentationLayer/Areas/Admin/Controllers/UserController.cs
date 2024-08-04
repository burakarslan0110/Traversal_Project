using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
       private readonly IAppUserService _appuserService;
       private readonly IReservationService _reservationService;

        public UserController(IAppUserService appuserService, IReservationService reservationService)
        {
            _appuserService = appuserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appuserService.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appuserService.TGetByID(id);
            _appuserService.TDelete(values);
            return RedirectToAction("User","Admin");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appuserService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appuserService.TUpdate(appUser);
            return RedirectToAction("User", "Admin");
        }
        public IActionResult CommentUser(int id)
        {
            var values = _appuserService.TGetByID(id);
            return View(values);
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByApproved(id);
            return View(values);
        }






    }   
}
