using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR2.Entities.Instances;

namespace Module4PR2.Entities.Configs
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Budget).HasColumnType("money").IsRequired();
            builder.Property(p => p.StartedDate).HasColumnType("datetime2").HasMaxLength(7).IsRequired();
            builder.Property(p => p.ClientId).IsRequired();

            builder.HasMany(p => p.EmployeeProjects)
                   .WithOne(ep => ep.Project)
                   .HasForeignKey(ep => ep.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Client)
                   .WithMany(c => c.Projects)
                   .HasForeignKey(p => p.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Project>()
            {
                new Project() { ProjectId = 1, Name = "Internet auction", Budget = 500, StartedDate = DateTime.ParseExact("18.01.2023", "d", null), ClientId = 1 },
                new Project() { ProjectId = 2, Name = "Module 4 Homework 3", Budget = 200, StartedDate = DateTime.ParseExact("26.12.2022", "d", null), ClientId = 2 },
                new Project() { ProjectId = 3, Name = "Module 4 Practice 1", Budget = 200, StartedDate = DateTime.ParseExact("05.01.2023", "d", null), ClientId = 2 },
                new Project() { ProjectId = 4, Name = "Instagram Bot", Budget = 1000, StartedDate = DateTime.ParseExact("01.01.2023", "d", null), ClientId = 3 },
                new Project() { ProjectId = 5, Name = "Ford Focus", Budget = 700, StartedDate = DateTime.ParseExact("01.02.2022", "d", null), ClientId = 4 },
                new Project() { ProjectId = 6, Name = "Ford Fiesta", Budget = 600, StartedDate = DateTime.ParseExact("01.02.2022", "d", null), ClientId = 4 },
                new Project() { ProjectId = 7, Name = "Ford Mondeo", Budget = 750, StartedDate = DateTime.ParseExact("01.03.2022", "d", null), ClientId = 4 },
                new Project() { ProjectId = 8, Name = "Ford Mustang", Budget = 1500, StartedDate = DateTime.ParseExact("01.04.2022", "d", null), ClientId = 4 },
                new Project() { ProjectId = 9, Name = "Electro magnetic motor", Budget = 2000, StartedDate = DateTime.ParseExact("01.05.2022", "d", null), ClientId = 5 },
                new Project() { ProjectId = 10, Name = "Dynamo electric machine", Budget = 2500, StartedDate = DateTime.ParseExact("22.03.2022", "d", null), ClientId = 5 },
                new Project() { ProjectId = 11, Name = "Thermo magnetic motor", Budget = 2200, StartedDate = DateTime.ParseExact("15.01.2023", "d", null), ClientId = 5 },
            });
        }
    }
}