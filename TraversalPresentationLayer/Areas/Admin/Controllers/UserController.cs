using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
       private readonly IAppUserService _appuserService;
       private readonly IReservationService _reservationService;
        private readonly ICommentService _commentService;

        public UserController(IAppUserService appuserService, IReservationService reservationService, ICommentService commentService)
        {
            _appuserService = appuserService;
            _reservationService = reservationService;
            _commentService = commentService;
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
            return RedirectToAction("Index");
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByApproved(id);
            return View(values);
        }






    }   
}
