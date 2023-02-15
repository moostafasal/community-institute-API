namespace community_institute_API.Data.Domin
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public bool states { get; set; }
        public int classid { get; set; }
        public clases clases { get; set; }
        public int GradesId { get; set; }

        public Grades Grades { get; set; }


        public ICollection<Solution> Solutions { get; set; } = new HashSet<Solution>();


    }
}
