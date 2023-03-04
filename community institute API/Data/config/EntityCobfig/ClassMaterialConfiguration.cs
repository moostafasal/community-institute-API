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


            builder.HasOne(C => C.TA).WithMany(T => T.Materials).HasForeignKey(c => c.TAId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(C => C.professors).WithMany(P => P.Materials).HasForeignKey(c => c.proffID).OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);






        }
    }


}
