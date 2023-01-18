using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities.Instances;

namespace Module4HW3.Entities.Configs
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");
            builder.HasKey(o => o.OfficeId);
            builder.Property(o => o.Title).HasMaxLength(100).IsRequired();
            builder.Property(o => o.Location).HasMaxLength(100).IsRequired();

            builder.HasMany(o => o.Employees)
                   .WithOne(e => e.Office)
                   .HasForeignKey(e => e.OfficeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
