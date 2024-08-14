using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOs.MemberDTOs
{
	public class UserEditDTO
	{
		public int Id { get; set; }	
		public string Name { get; set; }
		public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
		public string? ImageURL { get; set; }
		public string? PhoneNumber { get; set; }
		public string Email { get; set; }
		public IFormFile? ImageFile { get; set; }
	}
}
