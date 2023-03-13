using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace community_institute_API.Data.config.EntityCobfig
{
    public class GroupConfiguration : IEntityTypeConfiguration<Groups>
    {
        //configer class for group
   
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.GroupName).IsRequired().HasMaxLength(50);
            builder.HasMany(e => e.classes)
                .WithOne(c => c.Group)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
