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

        public ICollection<Enrollment> Enrollments { get; set; }=new HashSet<Enrollment>();
        public ICollection<Subject> Subjects { get; set; }= new HashSet<Subject>();

        public ICollection<TAs> TAs { get; set; } = new HashSet<TAs>();


        public int? ProfessorId { get; set; }
        public Professors Professor { get; set; }
    }
}
