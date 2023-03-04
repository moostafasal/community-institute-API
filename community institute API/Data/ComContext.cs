using community_institute_API.Data.config.EntityCobfig;
using community_institute_API.Data.Domin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.RegularExpressions;

namespace community_institute_API.Data
{

    public class ComContext : IdentityDbContext<IdentityUser>
    {
        //context for database constructor
        public ComContext(DbContextOptions<ComContext> options) : base(options)
        {
            
        }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfig();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appuser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            
            
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new ClasesConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorsConfiguration());
            modelBuilder.ApplyConfiguration(new TAsConfiguration());
            modelBuilder.ApplyConfiguration(new GradesConfiguration());
            modelBuilder.ApplyConfiguration(new SolutionConfiguration());
            //modelBuilder.ApplyConfiguration(new FilesConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            //class mat
            modelBuilder.ApplyConfiguration(new ClassMaterialConfiguration());
            
            //assingment











        }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Groups> Groups { get; set; }

        public DbSet<clases> clases { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<TAs> TAs { get; set; }
        //proff
        public DbSet<Professors> Professors { get; set; }
        //class material
        public DbSet<ClassMaterial> ClassMaterials { get; set; }
        
        public DbSet<Grades> Grades { get; set; }
        //public DbSet<Files> Files { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

                



            //[prof




        }
}
