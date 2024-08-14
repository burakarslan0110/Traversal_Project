using DTOLayer.DTOs.MemberDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Member.Models;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[Controller]/[Action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDTO userEditdto = new UserEditDTO();
            userEditdto.Id = values.Id;
            userEditdto.Name = values.Name;
            userEditdto.Surname = values.Surname;
            userEditdto.PhoneNumber = values.PhoneNumber;
            userEditdto.Email = values.Email;
            userEditdto.ImageURL = values.ImageURL;
            ViewBag.ImageURL = values.ImageURL;
            return View(userEditdto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDTO p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.ImageFile.CopyToAsync(stream);
                user.ImageURL = imagename;
                ViewBag.ImageURL = user.ImageURL;
            }

            if (user.Email != p.Email)
            {
                var emailExists = await _userManager.FindByEmailAsync(p.Email);
                if (emailExists != null)
                {
                    ModelState.AddModelError(string.Empty,"Bu e-posta adresi başka bir kullanıcı tarafından kullanılmaktadır!");
                }
            }

            if (ModelState.IsValid)
            {
                user.Name = p.Name;
                user.Surname = p.Surname;
                user.PhoneNumber = p.PhoneNumber;
                user.Email = p.Email;
                ViewBag.ImageURL = user.ImageURL;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login", new { area = "" });
                }
            }
            ViewBag.ImageURL = user.ImageURL;
            return View(p);
           
        }

        public async Task<IActionResult> RemoveProfileImage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.ImageURL = null;
            ViewBag.ImageURL = user.ImageURL;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(result);
        }
    }
}
