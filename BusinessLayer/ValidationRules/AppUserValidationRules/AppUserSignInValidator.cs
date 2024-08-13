using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserSignInValidator : AbstractValidator<AppUserLoginDTO>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez!");
        }
    }
}
