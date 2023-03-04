namespace community_institute_API.DTOs
{
    public class EnrollmentDto
    {
        public string CourseName { get; set; }
        public string InstructorName { get; set; }

        //is enrolled
        public bool IsEnrolled { get; set; }

        //Grade
        public int Grade { get; set; }
    }
}
