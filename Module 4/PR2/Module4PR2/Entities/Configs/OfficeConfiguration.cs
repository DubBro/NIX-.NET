using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR2.Entities.Instances;

namespace Module4PR2.Entities.Configs
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");
            builder.HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).ValueGeneratedOnAdd();
            builder.Property(o => o.Title).HasMaxLength(100).IsRequired();
            builder.Property(o => o.Location).HasMaxLength(100).IsRequired();

            builder.HasMany(o => o.Employees)
                   .WithOne(e => e.Office)
                   .HasForeignKey(e => e.OfficeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Office>()
            {
                new Office() { OfficeId = 1, Title = "Capital", Location = "Kyiv" },
                new Office() { OfficeId = 2, Title = "Interceptor", Location = "Kharkiv" },
                new Office() { OfficeId = 3, Title = "Flying Dutchman", Location = "Lviv" },
                new Office() { OfficeId = 4, Title = "Black Pearl", Location = "Dnipro" },
            });
        }
    }
}