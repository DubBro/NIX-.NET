using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR2.Entities.Instances;

namespace Module4PR2.Entities.Configs
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

            builder.HasData(new List<EmployeeProject>()
            {
                new EmployeeProject()
                {
                    EmployeeProjectId = 1,
                    Rate = 500,
                    StartedDate = DateTime.ParseExact("18.01.2023", "d", null),
                    EmployeeId = 3,
                    ProjectId = 1
                },
                new EmployeeProject()
                {
                    EmployeeProjectId = 2,
                    Rate = 200,
                    StartedDate = DateTime.ParseExact("26.12.2022", "d", null),
                    EmployeeId = 6,
                    ProjectId = 2
                },
                new EmployeeProject()
                {
                    EmployeeProjectId = 3,
                    Rate = 200,
                    StartedDate = DateTime.ParseExact("05.01.2023", "d", null),
                    EmployeeId = 6,
                    ProjectId = 3
                },
                new EmployeeProject()
                {
                    EmployeeProjectId = 4,
                    Rate = 1000,
                    StartedDate = DateTime.ParseExact("01.01.2023", "d", null),
                    EmployeeId = 10,
                    ProjectId = 4
                },
                new EmployeeProject()
                {
                    EmployeeProjectId = 5,
                    Rate = 700,
                    StartedDate = DateTime.ParseExact("01.02.2022", "d", null),
                    EmployeeId = 4,
                    ProjectId = 5
                },
                new EmployeeProject()
                {
                    EmployeeProjectId = 6,
                    Rate = 2200,
                    StartedDate = DateTime.ParseExact("15.01.2023", "d", null),
                    EmployeeId = 8,
                    ProjectId = 11
                },
            });
        }
    }
}