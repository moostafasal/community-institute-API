using community_institute_API.Data.Domin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Data.config.EntityCobfig
{
    
       
        public class StudentConfiguration : IEntityTypeConfiguration<Student>
        {
            public void Configure(EntityTypeBuilder<Student> builder)
            {
                builder.HasKey(s => s.Id);

                builder.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(s => s.Age)
                    .IsRequired();

                builder.Property(s => s.ImageURL)
                    .HasMaxLength(200);

                builder.HasOne(s => s.User)
                    .WithOne()
                    .HasForeignKey<Student>(s => s.UserId);

                builder.HasMany(s => s.Enrollments)
                    .WithOne(e => e.Student)
                    .HasForeignKey(e => e.StudentId);
            }
        }

    }


