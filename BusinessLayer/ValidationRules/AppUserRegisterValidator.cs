using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez!");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("E-posta alanı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola doğrulama alanı boş geçilemez!");
            
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Parola minimum 8 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Parola maksimum 50 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Belirlediğiniz parola tekrar girdiğiniz parolayla uyuşmadı. Lütfen tekrar deneyin!");

        }
    }
}
