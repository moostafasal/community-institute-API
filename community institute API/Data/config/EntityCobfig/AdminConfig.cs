using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        //Admin Entity Configuration
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasOne(A => A.User)
              .WithOne()
              .HasForeignKey<Admin>(A=> A.UserId);
        }
    }
}
