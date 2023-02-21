namespace community_institute_API.Data.Domin
{
    public class Assignment
    {

        public int Id { get; set; }
        public string ?Name { get; set; }
        public string? Url { get; set; }
        
        //public int FileId { get; set; }
        //public Files ?File { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Description { get; set; } = String.Empty;

        public int proffid { get; set; }
        public Professors ?professors { get; set; }
        public int TAid { get; set; }
        public TAs TA { get; set; }

        public DateTime Deadline { get; set; }
        public ICollection<Solution> Solutions { get; set; }



    }
}
