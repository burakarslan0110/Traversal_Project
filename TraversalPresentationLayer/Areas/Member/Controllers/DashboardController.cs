using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageURL;
            return View();
        }
    }
}
