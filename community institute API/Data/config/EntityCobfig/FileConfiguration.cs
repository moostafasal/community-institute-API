using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using community_institute_API.Data.Domin;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class FilesConfiguration : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.FileName)
                .IsRequired();

            builder.Property(f => f.Url)
                .IsRequired();

            builder.Property(f => f.Timestamp)
                .IsRequired();

            builder.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
