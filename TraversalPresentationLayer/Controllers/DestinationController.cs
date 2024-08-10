using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
       private readonly IDestinationService _destinationService;
       private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.v12 = "12";
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public async Task <IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = user.Id;
            var values = _destinationService.TGetDestinationWithGuide(id);
           
            return View(values);  
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
