using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR1.Entities.Instances;

namespace Module4PR1.Entities.Configs
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title");
            builder.HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(t => t.Employees)
                   .WithOne(e => e.Title)
                   .HasForeignKey(e => e.TitleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}