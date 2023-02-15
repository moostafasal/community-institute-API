namespace community_institute_API.Data.config.EntityCobfig
{
    using community_institute_API.Data.Domin;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClassMaterialConfiguration : IEntityTypeConfiguration<ClassMaterial>
    {
        public void Configure(EntityTypeBuilder<ClassMaterial> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Timestamp)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(c => c.Files)
                .WithMany()
                .HasForeignKey(c => c.FileId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(C => C.TA).WithMany(T => T.Materials).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(C => C.professors).WithMany(P => P.Materials).OnDelete(DeleteBehavior.SetNull);





        }
    }


}
