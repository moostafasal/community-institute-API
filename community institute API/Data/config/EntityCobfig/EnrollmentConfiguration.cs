using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace community_institute_API.Data.config.EntityCobfig
{


    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder .Property(e => e.State)
             .HasConversion<int>();
            


            //builder.HasOne(e => e.Grades)
            //    .WithOne(g => g.Enrollment)
            //    .HasForeignKey<Grades>(g => g.EnrollmentId);

            builder.HasMany(e => e.Solutions)
                .WithOne(s => s.Enrollment)
                .HasForeignKey(s => s.EnrollmentId);
        }
    }

}



