namespace community_institute_API.DTOs
{
    public class ClassDto
    {
        //proff id
        public int GroupId { get; set; }
        //ProfessorId
        public Guid ProfessorId { get; set; }
        //subject id
        public int SubjectId { get; set; }
        //name
        public string Name { get; set; }
        //description
        public string description { get; set; }
        
    }
}
