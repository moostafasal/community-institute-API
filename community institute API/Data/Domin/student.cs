using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace community_institute_API.Data.Domin
{
    public class Student
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }
    
}
