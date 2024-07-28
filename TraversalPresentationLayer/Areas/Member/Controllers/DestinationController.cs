using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
