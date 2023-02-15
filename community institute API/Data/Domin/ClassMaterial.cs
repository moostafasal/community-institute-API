namespace community_institute_API.Data.Domin
{
    public class ClassMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FileId { get; set; }
        public Files Files { get; set; }
        public int TAId { get; set; }
        public TAs TA { get; set; }
        public int proffID { get; set; }

        public Professors professors { get; set; }
   

        public DateTime Timestamp { get; set; } = DateTime.Now;

    }
}
