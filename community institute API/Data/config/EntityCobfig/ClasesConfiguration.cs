namespace community_institute_API.Data.config.EntityCobfig;
using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClasesConfiguration : IEntityTypeConfiguration<clases>
{
    public void Configure(EntityTypeBuilder<clases> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Groups)
            .WithOne(g => g.Class)
            .HasForeignKey<clases>(c => c.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Enrollments)
            .WithOne(e => e.clases)
            .HasForeignKey(e => e.classid)
            .OnDelete(DeleteBehavior.Cascade);
        //relation between classes and subject
        builder.HasOne(c => c.Subject)
            .WithMany(s => s.classes)
            .HasForeignKey(c => c.SubjectId);




        builder.HasOne(c => c.Professor)
            .WithMany(p => p.clases)
            .HasForeignKey(c => c.ProfessorId);

    }
}

