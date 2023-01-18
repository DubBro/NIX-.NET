using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR1.Entities.Instances;

namespace Module4PR1.Entities.Configs
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject");
            builder.HasKey(ep => ep.EmployeeProjectId);
            builder.Property(e => e.EmployeeProjectId).ValueGeneratedOnAdd();
            builder.Property(ep => ep.Rate).HasColumnType("money").IsRequired();
            builder.Property(ep => ep.StartedDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired();
            builder.Property(ep => ep.EmployeeId).IsRequired();
            builder.Property(ep => ep.ProjectId).IsRequired();

            builder.HasOne(ep => ep.Employee)
                   .WithMany(e => e.EmployeeProjects)
                   .HasForeignKey(ep => ep.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ep => ep.Project)
                   .WithMany(p => p.EmployeeProjects)
                   .HasForeignKey(ep => ep.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}