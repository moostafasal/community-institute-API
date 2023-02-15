using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class SolutionConfiguration : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired();

            builder.Property(s => s.FileId)
                   .IsRequired();

            builder.HasOne(s => s.File)
                   .WithOne()
                   .HasForeignKey<Solution>(s => s.FileId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Assignment)
                   .WithMany(a => a.Solutions)
                   .HasForeignKey(s => s.AssignmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Enrollment)
                   .WithMany(e => e.Solutions)
                   .HasForeignKey(s => s.EnrollmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
