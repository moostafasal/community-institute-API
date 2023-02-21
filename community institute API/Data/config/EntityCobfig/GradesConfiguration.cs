using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
   
        public class GradesConfiguration : IEntityTypeConfiguration<Grades>
        {
            public void Configure(EntityTypeBuilder<Grades> builder)
            {

            builder.HasKey(g => g.Id);
            builder.Property(g => g.mid);
            builder.Property(g => g.final);
            builder.HasOne(g => g.Enrollment)
                    .WithOne(e => e.Grades)
                    .HasForeignKey<Enrollment>(e => e.GradesId);

        }
        }

    
}
