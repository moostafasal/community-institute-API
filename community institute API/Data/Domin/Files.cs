﻿using Microsoft.AspNetCore.Identity;

namespace community_institute_API.Data.Domin
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }

        public int UserId { get; set; }
        public IdentityUser User { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;


    }
}
