namespace community_institute_API.Data.Domin
{
    public class Assignment
    {

        public int Id { get; set; }
        public string ?Name { get; set; }
        public string? FileUrl { get; set; }
        
        public int classid { get; set; }
        public clases? classes { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Description { get; set; } = String.Empty;

        public Guid proffid { get; set; }
        public Professors ?professors { get; set; }
        public Guid TAid { get; set; }
        public TAs? TA { get; set; }

        public DateTime Deadline { get; set; }
        public ICollection<Solution> ?Solutions { get; set; }



    }
}
