﻿using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Data.Domin
{
    public class ClassMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int ClassId { get; set; }
        public clases clases { get; set; }
        

        public Guid ?TAId { get; set; }
        public TAs ?TA { get; set; }
        public Guid proffID { get; set; }

        public Professors professors { get; set; }


        public DateTime ?Timestamp { get; set; } = DateTime.Now;

    }
}
