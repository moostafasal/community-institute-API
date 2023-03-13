namespace community_institute_API.DTOs
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int? Year { get; set; }
        public string AcademicId { get; set; }
        // photo
        //GPA
        public decimal? GPA { get; set; }
        public string Photo { get; set; }
        public List<EnrollmentDto> Enrollments { get; set; }
    }
}
