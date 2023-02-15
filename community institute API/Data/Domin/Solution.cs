namespace community_institute_API.Data.Domin
{
    public class Solution
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public int FileId { get; set; }
        public Files File { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }
        public int EnrollmentId { get; set; }

        public Enrollment Enrollment { get; set; }

    }
}
