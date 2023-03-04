using System.ComponentModel.DataAnnotations;

namespace community_institute_API.DTOs
{
    public class RegisterAdminDto
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = default!;
    }
}
