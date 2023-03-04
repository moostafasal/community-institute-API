using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace community_institute_API.Data.Domin
{
    public class TAs
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string?  ImgUrl { get; set; }
        public string? UserId { get; set; }
        public Appuser User { get; set; }
        //acdimc id
        public string? AcademicId { get; set; }
        
        public ICollection<clases> Classes { get; set; }=new HashSet<clases>();
        public ICollection<ClassMaterial> Materials { get; set; } = new HashSet<ClassMaterial>();
        public ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>(); 





    }
}
