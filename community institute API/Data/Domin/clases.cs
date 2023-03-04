using System.Text.RegularExpressions;

namespace community_institute_API.Data.Domin
{
    public class clases
    {
        public int Id { get; set; }

        //descriotion
        public string Description { get; set; }
        public int GroupId { get; set; }
        public Groups? Groups { get; set; }
        //relation between subject class hass manny subkect and subject has one class
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        
        
        public ICollection<Enrollment> Enrollments { get; set; }=new HashSet<Enrollment>();

        public ICollection<TAs> TAs { get; set; } = new HashSet<TAs>();


        public int? ProfessorId { get; set; }
        public Professors Professor { get; set; }
    }
}
