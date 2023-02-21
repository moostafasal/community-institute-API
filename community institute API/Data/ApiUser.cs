using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Data
{
    public class ApiUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
