using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidationRules
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad soyad kısmı boş geçilemez! Lütfen tekrar deneyin...!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta kısmı boş geçilemez! Lütfen tekrar deneyin...!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş geçilemez! Lütfen tekrar deneyin...!");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj kısmı boş geçilemez! Lütfen tekrar deneyin...!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Ad soyad kısmı minimum 5 karakter olabilir!");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("E-posta kısmı minimum 5 karakter olabilir!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu kısmı minimum 5 karakter olabilir!");
            RuleFor(x => x.MessageBody).MinimumLength(10).WithMessage("Mesaj kısmı minimum 10 karakter olabilir!");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz!");
        }
    }
}
