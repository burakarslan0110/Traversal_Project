using System.ComponentModel.DataAnnotations;

namespace TraversalPresentationLayer.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Parola alanı boş geçilemez!")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Parola minimum 8 karakterden oluşmalıdır ve maksimum 50 karakterden oluşmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Onay parolası alanı boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Onay parolası ile parola eşleşmelidir.")]
        public string ConfirmPassword { get; set; }
    }
}
