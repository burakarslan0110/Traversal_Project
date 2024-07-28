using System.ComponentModel.DataAnnotations;

namespace Traversal.Areas.Member.Models
{
	public class UserEditViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }

        [StringLength(100, ErrorMessage = "Parola en az {2} ve en fazla {1} karakter olmalıdır!", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Girdiğiniz parolalar birbirleriyle uyuşmuyor, lütfen tekrar deneyin!")]
        public string ConfirmPassword { get; set; }
		public string ImageURL { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public IFormFile ImageFile { get; set; }
	}
}
