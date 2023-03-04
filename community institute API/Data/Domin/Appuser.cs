using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Data.Domin
{
    public class Appuser : IdentityUser
    {
        
        //creat id
        //public int Id { get; set; }
        public string FullName { get; set; }

        public string? ImgUrl { get; set; }
        public string? AcademicId { get; set; }


        





    }
}
