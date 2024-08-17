using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactCController : Controller
    {
        private readonly IContactService _contactService;

        public ContactCController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactService.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            _contactService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
