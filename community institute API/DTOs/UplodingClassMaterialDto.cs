using community_institute_API.Data.Domin;

namespace community_institute_API.DTOs
{
    public class UplodingClassMaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid userId { get; set; }
        public IFormFile File { get; set; }
        // time
        //class id
        public int ClassId { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.Now;

    


    }
}
