using System.Security.Claims;

namespace community_institute_API.Data.Domin
{
    public class Groups
    {
      
        public int Id { get; set; }
        //number
        public int Number { get; set; }
        public string GroupName { get; set; }
        
        //classes entity  relation many to one
        public ICollection<clases> classes { get; set; } = new HashSet<clases>();






    }
}
