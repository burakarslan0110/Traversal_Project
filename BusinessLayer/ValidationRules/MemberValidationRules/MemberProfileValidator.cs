using DTOLayer.DTOs.MemberDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace BusinessLayer.ValidationRules.MemberValidationRules
{
    public class MemberProfileValidator : AbstractValidator<UserEditDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        public MemberProfileValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta alanı boş geçilemez!").EmailAddress().WithMessage("Geçerli bir e-posta adresi girin!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez!").
                                     Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$")
            .WithMessage("Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir!").
            MinimumLength(8).WithMessage("Parola minimum 8 karakterden oluşmalıdır.").
            MaximumLength(50).WithMessage("Parola maksimum 50 karakterden oluşmalıdır.");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola doğrulama alanı boş geçilemez!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Belirlediğiniz parola tekrar girdiğiniz parolayla uyuşmadı. Lütfen tekrar deneyin!");
        }
    }
}
