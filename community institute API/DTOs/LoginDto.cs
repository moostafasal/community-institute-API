using System.ComponentModel.DataAnnotations;

namespace community_institute_API.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string ?Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string ? Password { get; set; }
    }
}
