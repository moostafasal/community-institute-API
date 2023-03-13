using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Xml.Linq;

namespace community_institute_API.Data.Domin
{
    public class Subject
    {
        public Subject()
        {
                
        }
        public int Id { get; set; }

        public string Code { get; set; }

        public int Units { get; set; }
        //name
        public string Name { get; set; }
        public int year { get; set; }
        public ICollection<clases> classes { get; set; } = new HashSet<clases>();
        

    }
}
