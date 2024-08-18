using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUOW;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalPresentationLayer.Areas.Admin.Models;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var values = _accountService.TGetAccountWithGuide();
            return View(values);
        }


        [HttpGet]
        public IActionResult SendUOW()
        {
            List<SelectListItem> values = (from x in _accountService.TGetAccountWithGuide()
                                           select new SelectListItem
                                           {
                                               Text = x.Guide.GuideName,
                                               Value = x.AccountID.ToString()
                                           }).ToList();
            ViewBag.VGDX = values;
            return View();
        }

        [HttpPost]
        public IActionResult SendUOW(AccountViewModel model)
        {
            var valueSender = _accountService.TGetByID(model.SenderID);
            var valueReceiver = _accountService.TGetByID(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver,
            };

            _accountService.TMultiUpdate(modifiedAccount);
            return RedirectToAction("Index");
        }
    }
}
