using System.ComponentModel.DataAnnotations;

namespace community_institute_API.Data.Domin
{
    public class Grades
    {
        public Grades()
        {

        }
        public int Id { get; set; }
        public int mid { get; set; }
        public int final { get; set; }
        [Required]
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }


    }
}
