using System.ComponentModel.DataAnnotations;

namespace community_institute_API.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Passowrd { get; set; }
    }
}
