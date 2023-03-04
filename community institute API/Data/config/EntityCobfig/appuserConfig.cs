using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class AppuserConfiguration : IEntityTypeConfiguration<Appuser>
    {
        public void Configure(EntityTypeBuilder<Appuser> builder)
        {
            // Set table name
            builder.ToTable("users");

            // Set primary key

            // Set required fields
            builder.Property(u => u.FullName).IsRequired();

            // Set relationships
            //builder.HasMany(u => u.Materials)
            //    .WithOne(m => m.User)
            //    .HasForeignKey(m => m.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(u => u.clases)
            //    .WithOne(c => c.user)
            //    .HasForeignKey(c => c.userid)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(u => u.Assignment)
            //    .WithOne(a => a.user)
            //    .HasForeignKey(a => a.userid)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
