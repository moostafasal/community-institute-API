using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace community_institute_API.Data.Domin
{
    public class clases
    {
        public int Id { get; set; }
        //name
        public string Name { get; set; }

        //descriotion



        public string Description { get; set; }
        //relation to group one
        public int GroupId { get; set; }
        public Groups Group { get; set; }
        
        



        //relation between subject class hass manny subkect and subject has one class
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        
        
        public ICollection<Enrollment> Enrollments { get; set; }=new HashSet<Enrollment>();

        public ICollection<TAs> TAs { get; set; } = new HashSet<TAs>();


        public int? ProfessorId { get; set; }
        public Professors Professor { get; set; }
    }
}
