using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
	public class UserRegisterViewModel
	{
        [Required(ErrorMessage = "Lütfen adınızı girin! ")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı girin! ")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adınızı girin!")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen e-posta adresinizi girin! ")]
		public string EMail { get; set; }

		[Required(ErrorMessage = "Lütfen parolanızı tekrar girin! ")]
		[StringLength(100, ErrorMessage = "Parola en az {2} ve en fazla {1} karakter olmalıdır!", MinimumLength = 8)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir!")]
		public string Password { get; set; }

		[Compare("Password",ErrorMessage = "Girdiğiniz parolalar birbirleriyle uyuşmuyor, lütfen tekrar deneyin!")]
		public string ConfirmPassword { get; set; }
	}
}
