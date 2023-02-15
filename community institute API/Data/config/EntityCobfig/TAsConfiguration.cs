using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class TAsConfiguration : IEntityTypeConfiguration<TAs>
    {
        public void Configure(EntityTypeBuilder<TAs> builder)
        {
            builder.ToTable("TAs");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired();


            builder.HasMany(t => t.Materials)
                   .WithOne(m => m.TA)
                   .HasForeignKey(m => m.TAId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.Assignment)
                   .WithOne(a => a.TA)
                   .HasForeignKey(a => a.TAid)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.File)
                   .WithMany()
                   .HasForeignKey(t => t.FileId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
