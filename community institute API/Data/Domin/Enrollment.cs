namespace community_institute_API.Data.Domin
{
    public class Enrollment
    {
        
        public int Id { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        //public bool states { get; set; }
        public EnrollmentState State { get; set; }

        public int classid { get; set; }
        public clases clases { get; set; }
 


        public ICollection<Solution> Solutions { get; set; } = new HashSet<Solution>();

        public enum EnrollmentState
        {
            Pending,
            Approved,
            Rejected
        }
    }
}
