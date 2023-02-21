    using community_institute_API.Data.Domin;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace community_institute_API.Data.config.EntityCobfig
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(a => a.Name)
                   .IsRequired();

            builder.Property(a => a.Timestamp)
                   .IsRequired();

            builder.Property(a => a.Deadline)
                   .IsRequired();

            //builder.HasOne(a => a.File)
            //       .WithOne()
            //       .HasForeignKey<Assignment>(a => a.FileId)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.professors)
                   .WithMany(p => p.Assignment)
                   .HasForeignKey(a => a.proffid)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.TA)
                   .WithMany(t => t.Assignment)
                   .HasForeignKey(a => a.TAid)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Solutions)
                   .WithOne(s => s.Assignment)
                   .HasForeignKey(s => s.AssignmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
