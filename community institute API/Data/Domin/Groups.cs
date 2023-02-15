using System.Security.Claims;

namespace community_institute_API.Data.Domin
{
    public class Groups
    {
        public int id { get; set; }
        public string GroupName { get; set; }

        public int ClassId { get; set; }
        public clases Class { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; }=new HashSet<GroupUser>();
    }
}
