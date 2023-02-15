using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Units)
                .IsRequired();

            builder.HasOne(s => s.Classes)
                .WithMany(c => c.Subject)
                .HasForeignKey(s => s.classid)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
