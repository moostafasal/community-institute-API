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
        public int classid { get; set; }
        public clases Classes { get; set; }

    }
}
