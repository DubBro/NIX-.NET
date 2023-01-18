using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR1.Entities.Instances;

namespace Module4PR1.Entities.Configs
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.HiredDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired();
            builder.Property(e => e.DateOfBirth).HasColumnType("date").IsRequired(false);
            builder.Property(e => e.OfficeId).IsRequired();
            builder.Property(e => e.TitleId).IsRequired();

            builder.HasOne(e => e.Office)
                   .WithMany(o => o.Employees)
                   .HasForeignKey(e => e.OfficeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Title)
                   .WithMany(t => t.Employees)
                   .HasForeignKey(e => e.TitleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.EmployeeProjects)
                   .WithOne(ep => ep.Employee)
                   .HasForeignKey(ep => ep.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}