using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalPresentationLayer.Models;

namespace TraversalPresentationLayer.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel p)
        {
            // Kullanıcının e-posta adresi sistemde kayıtlı mı kontrol et
            var user = await _userManager.FindByEmailAsync(p.Email);

            if (user == null)
            {
                // E-posta adresi sistemde kayıtlı değilse, kullanıcıya bilgi ver
                ViewBag.Message = "Bu E-posta adresi sistemde kayıtlı değil.";
                return View();
            }

            // Şifre sıfırlama token'ını ve linkini oluştur
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            // E-posta mesajını oluştur
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MyTraversalProject", "mytraversalproject@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.Email);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Şifre Değişiklik Talebi - Traversal";

            // E-posta gönderimi
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("mytraversalproject@gmail.com", "ujwf krbw srhn hqgd");
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            // Kullanıcıya e-posta gönderildiği bilgisini ver
            ViewBag.Message = "Şifre sıfırlama bağlantısı e-posta adresinize gönderilmiştir.";
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            // Token ve userId'nin geçerliliğini doğrulayın
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                // Geçersiz parametreler için uygun bir hata mesajı döndürün
                return RedirectToAction("Error", "Home");
            }

            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel p)
        {
            var userId = TempData.Peek("userId")?.ToString();
            var token = TempData.Peek("token")?.ToString();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "Şifre sıfırlama bağlantısı geçersiz.");
                return View(p);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(p);
            }

            var result = await _userManager.ResetPasswordAsync(user, token, p.Password);

            if (result.Succeeded)
            {
                // Şifre değişikliği başarılı, kullanıcıyı yönlendirin
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                // Şifre değişikliği başarısız, hata mesajlarını ekleyin
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
              
                }

   

                return View(p);
            }
        }

    }

}
