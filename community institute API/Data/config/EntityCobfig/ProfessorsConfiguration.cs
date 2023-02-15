using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class ProfessorsConfiguration : IEntityTypeConfiguration<Professors>
    {
        public void Configure(EntityTypeBuilder<Professors> builder)
        {
            // Primary key
            builder.HasKey(p => p.Id);

            // Required properties
            builder.Property(p => p.Name)
                .IsRequired();

            // Optional properties
            builder.Property(p => p.ImgUrl)
                .HasMaxLength(250);

            // Relationships
            builder.HasMany(p => p.Materials)
                .WithOne(m => m.professors)
                .HasForeignKey(m => m.proffID)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.clases)
                .WithOne(c => c.Professor)
                .HasForeignKey(c => c.ProfessorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Assignment)
                .WithOne(a => a.professors)
                .HasForeignKey(a => a.proffid)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.File)
                .WithOne()
                .HasForeignKey<Professors>(p => p.FileId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }


}
