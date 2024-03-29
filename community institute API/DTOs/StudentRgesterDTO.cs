﻿using System.ComponentModel.DataAnnotations;
using static community_institute_API.Helper.FilterMethod;

namespace community_institute_API.DTOs
{
    public class StudentRegisterDto
    {
        
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@hti\.edu\.eg$", ErrorMessage = "The email must be a valid HTI email address ending with @hti.edu.eg")]
        public string Email { get; set; }
        
        public string? AcademicId { get; set; }
        //Rgex 

        [Required]
        //password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        




        [Required]
        [Display(Name = "Age")]
        [Range(18, 50, ErrorMessage = "Age must be between 18 and 50")]
        public int Age { get; set; }
        [Range(1, 4, ErrorMessage = "Year must be between 1 and 4")]
        public int? year { get; set; }
        [Range(0, 4, ErrorMessage = "GPA must be between 0 and 4")]
        public decimal? GPA { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif" })]
        public IFormFile Image { get; set; }
        
        
        
    }
    

}
