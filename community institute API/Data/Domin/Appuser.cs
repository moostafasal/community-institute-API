using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Data.Domin
{
    public class Appuser : IdentityUser
    {

        public string? FullName { get; set; }
        
        public string? ImgUrl { get; set; }

        public string? Role { get; set; }


        //make academic id unique
        
        public string? AcademicId { get; set; }


        





    }
}
