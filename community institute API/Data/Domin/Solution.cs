using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Data.Domin
{
    public class Solution
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Name { get; set; }
        //public string UserId { get; set; }
        //public Appuser User { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }
        public int EnrollmentId { get; set; }

        public Enrollment Enrollment { get; set; }

    }
}
