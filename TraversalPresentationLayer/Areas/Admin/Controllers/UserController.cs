using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        AppUserManager _appUserManager = new AppUserManager(new EFAppUserDal());
        ReservationManager _reservationManager = new ReservationManager(new EFReservationDal());
        public IActionResult Index()
        {
            var values = _appUserManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserManager.TGetByID(id);
            _appUserManager.TDelete(values);
            return RedirectToAction("User","Admin");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserManager.TUpdate(appUser);
            return RedirectToAction("User", "Admin");
        }
        public IActionResult CommentUser(int id)
        {
            var values = _appUserManager.TGetByID(id);
            return View(values);
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationManager.GetListWithReservationByApproved(id);
            return View(values);
        }







    }   
}
