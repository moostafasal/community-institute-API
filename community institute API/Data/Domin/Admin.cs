namespace community_institute_API.Data.Domin
{
    public class Admin
    {
        //name
        public string Name { get; set; }
        public int Id { get; set; }
        //fk appuser
        public string ?UserId { get; set; }
        public Appuser User { get; set; }
        //crated at
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        
        

    }
}
