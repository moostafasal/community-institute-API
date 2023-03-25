namespace community_institute_API.DTOs
{
    public class UplodingAssignmentDto
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid userId { get; set; }
        public DateTime Deadline { get; set; }
        public IFormFile File { get; set; }
    }
}
