using System.Text.RegularExpressions;

namespace community_institute_API.Data.Domin
{
    public class clases
    {
        public int Id { get; set; }


        public int GroupId { get; set; }
        public Groups Groups { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }=new HashSet<Enrollment>();
        public ICollection<Subject> Subject { get; set; }

        public ICollection<TAs> TAs { get; set; }


        public int ProfessorId { get; set; }
        public Professors Professor { get; set; }
    }
}
