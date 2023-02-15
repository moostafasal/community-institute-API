using community_institute_API.Data.config.EntityCobfig;
using community_institute_API.Data.Domin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.RegularExpressions;

namespace community_institute_API.Data
{
    //adding the identity db context to the context class

    public class ComContext : IdentityDbContext<IdentityUser>
    {
        //context for database constructor
        public ComContext(DbContextOptions<ComContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        //    modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
        //    modelBuilder.ApplyConfiguration(new ClasesConfiguration());
        //    modelBuilder.ApplyConfiguration(new ClassMaterialConfiguration());
        //    modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        //    modelBuilder.ApplyConfiguration(new FilesConfiguration());
        //    modelBuilder.ApplyConfiguration(new SolutionConfiguration());
        //    modelBuilder.ApplyConfiguration(new ProfessorsConfiguration());
        //    modelBuilder.ApplyConfiguration(new StudentConfiguration());
        //    modelBuilder.ApplyConfiguration(new TAsConfiguration());
            
        //}

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<clases> Class { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Professors> Professors { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TAs> TAs { get; set; }
        



    }
}
