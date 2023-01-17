using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW3.Entities.Instances;

namespace Module4HW3.Entities.Configs
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(p => p.ProjectId);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Budget).HasColumnType("money").IsRequired();
            builder.Property(p => p.StartedDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired();

            builder.HasMany(p => p.EmployeeProjects)
                   .WithOne(ep => ep.Project)
                   .HasForeignKey(ep => ep.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
