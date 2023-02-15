using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace community_institute_API.Data.Domin
{
    public class TAs
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int FileId { get; set; }
        public Files File { get; set; }

        public ICollection<clases> Classes { get; set; }=new HashSet<clases>();
        public ICollection<ClassMaterial> Materials { get; set; } = new HashSet<ClassMaterial>();
        public ICollection<Assignment> Assignment { get; set; } = new HashSet<Assignment>(); 





    }
}
