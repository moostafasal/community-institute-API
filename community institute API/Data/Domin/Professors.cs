namespace community_institute_API.Data.Domin
{
    public class Professors
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public Files File { get; set; }
        public string Name { get; set; }

 
        public string ImgUrl { get; set; }
        public ICollection<ClassMaterial> Materials { get; set; }=new List<ClassMaterial>();
        public ICollection<clases> clases { get; set; } = new List<clases>();

        public ICollection<Assignment> Assignment { get; set; }= new List<Assignment>();
    }
}
