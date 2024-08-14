using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        public AppUserRegisterValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez!");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("E-posta alanı boş geçilemez!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez!").
                                     Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$")
            .WithMessage("Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir!").
            MinimumLength(8).WithMessage("Parola minimum 8 karakterden oluşmalıdır.").
            MaximumLength(50).WithMessage("Parola maksimum 50 karakterden oluşmalıdır.");

			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola doğrulama alanı boş geçilemez!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Belirlediğiniz parola tekrar girdiğiniz parolayla uyuşmadı. Lütfen tekrar deneyin!");

            RuleFor(x => x.Username).Custom((username, context) =>
            {
                var user = _userManager.FindByNameAsync(username).Result;
                if (user != null)
                {
                    context.AddFailure("Bu kullanıcı adı alınmış, lütfen tekrar deneyin.");
                }
            });

            RuleFor(x => x.EMail).Custom((email, context) =>
            {
                var user = _userManager.FindByEmailAsync(email).Result;
                if (user != null)
                {
                    context.AddFailure("Bu e-posta adresi alınmış, lütfen tekrar deneyin.");
                }
            });
        }


    }
}
