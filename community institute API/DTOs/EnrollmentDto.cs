namespace community_institute_API.DTOs
{
    public enum EnrollmentState
    {
        Pending,
        Approved,
        Rejected
    }

    public class EnrollmentDto
    {
        public string CourseName { get; set; }
        public string InstructorName { get; set; }

        // Enrollment state
        public EnrollmentState State { get; set; }

        // Is enrolled

        // Grade
        public int Grade { get; set; }
    }
}
