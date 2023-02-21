namespace community_institute_API.Data.Domin
{
    public class Professors
    {
        public Professors()
        {

        }
        public Professors(string name,string imgUrl)
        {
            Name = name;
          
            ImgUrl = imgUrl;
        }
        
        public int Id { get; set; }
  
        public string Name { get; set; }

 
        public string ?ImgUrl { get; set; }
        public ICollection<ClassMaterial> Materials { get; set; }=new List<ClassMaterial>();
        public ICollection<clases> clases { get; set; } = new List<clases>();

        public ICollection<Assignment> Assignment { get; set; }= new List<Assignment>();
    }
}
