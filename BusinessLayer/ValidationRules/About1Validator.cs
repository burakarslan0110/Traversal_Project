using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class About1Validator : AbstractValidator<About1>
	{
        public About1Validator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez! Lütfen tekrar deneyin...!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Görsel kısmı boş geçilemez! Lütfen tekrar deneyin...!");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez! Lütfen tekrar deneyin...!");
            RuleFor(x => x.Description1).MinimumLength(25).WithMessage("Açıklama kısmı minimum 25 karakter olabilir!");
            RuleFor(x => x.Description2).MinimumLength(25).WithMessage("Açıklama kısmı minimum 25 karakter olabilir!");
        }
    }
}
