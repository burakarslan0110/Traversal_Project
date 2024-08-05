using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementEditValidator : AbstractValidator<AnnouncementEditDTO>
    {
        public AnnouncementEditValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Duyuru başlığı boş geçilemez!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru içeriği boş geçilemez!");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Duyuru başlığı minimum 10 karakter olabilir!");
            RuleFor(x => x.Content).MinimumLength(15).WithMessage("Duyuru içeriği minimum 15 karakter olabilir!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Duyuru başlığı maksimum 50 karakter olabilir!");
            RuleFor(x => x.Content).MaximumLength(700).WithMessage("Duyuru içeriği maksimum 700 karakter olabilir!");
        }
    }
}
