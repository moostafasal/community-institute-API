using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace community_institute_API.Data.Domin
{
    public class Student
    {//add 
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
        //yar
        public int? year { get; set; }

        //GPA
        public decimal? GPA { get; set; }
        
        [Display(Name = "Image URL")]
        //acdimicId
        public string? AcademicId { get; set; }
        
        public string ?ImageURL { get; set; }
        

        
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Appuser User { get; set; }
    }
    
}
