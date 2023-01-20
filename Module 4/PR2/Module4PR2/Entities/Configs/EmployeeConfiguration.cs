using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR2.Entities.Instances;

namespace Module4PR2.Entities.Configs
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

            builder.HasData(new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    FirstName = "Steve",
                    LastName = "Jobs",
                    HiredDate = DateTime.ParseExact("10.11.2021", "d", null),
                    DateOfBirth = DateTime.ParseExact("24.02.1955", "d", null),
                    OfficeId = 1,
                    TitleId = 1,
                },
                new Employee()
                {
                    EmployeeId = 2,
                    FirstName = "Mark",
                    LastName = "Zuckerberg",
                    HiredDate = DateTime.ParseExact("10.11.2021", "d", null),
                    DateOfBirth = DateTime.ParseExact("14.05.1984", "d", null),
                    OfficeId = 1,
                    TitleId = 4,
                },
                new Employee()
                {
                    EmployeeId = 3,
                    FirstName = "Bill",
                    LastName = "Gates",
                    HiredDate = DateTime.ParseExact("10.11.2021", "d", null),
                    DateOfBirth = DateTime.ParseExact("28.10.1955", "d", null),
                    OfficeId = 1,
                    TitleId = 2,
                },
                new Employee()
                {
                    EmployeeId = 4,
                    FirstName = "Elon",
                    LastName = "Musk",
                    HiredDate = DateTime.ParseExact("10.11.2021", "d", null),
                    DateOfBirth = DateTime.ParseExact("28.06.1971", "d", null),
                    OfficeId = 1,
                    TitleId = 3,
                },
                new Employee()
                {
                    EmployeeId = 5,
                    FirstName = "James",
                    LastName = "Norrington",
                    HiredDate = DateTime.ParseExact("08.02.2022", "d", null),
                    OfficeId = 2,
                    TitleId = 1,
                },
                new Employee()
                {
                    EmployeeId = 6,
                    FirstName = "Steve",
                    LastName = "Wozniak",
                    HiredDate = DateTime.ParseExact("22.02.2022", "d", null),
                    DateOfBirth = DateTime.ParseExact("11.09.1950", "d", null),
                    OfficeId = 2,
                    TitleId = 2,
                },
                new Employee()
                {
                    EmployeeId = 7,
                    FirstName = "Davy",
                    LastName = "Jones",
                    HiredDate = DateTime.ParseExact("03.03.2022", "d", null),
                    OfficeId = 3,
                    TitleId = 1,
                },
                new Employee()
                {
                    EmployeeId = 8,
                    FirstName = "Bill",
                    LastName = "Turner",
                    HiredDate = DateTime.ParseExact("03.04.2022", "d", null),
                    OfficeId = 3,
                    TitleId = 4,
                },
                new Employee()
                {
                    EmployeeId = 9,
                    FirstName = "Jack",
                    LastName = "Sparrow",
                    HiredDate = DateTime.ParseExact("10.01.2022", "d", null),
                    OfficeId = 4,
                    TitleId = 1,
                },
                new Employee()
                {
                    EmployeeId = 10,
                    FirstName = "Joshamee",
                    LastName = "Gibbs",
                    HiredDate = DateTime.ParseExact("11.03.2022", "d", null),
                    OfficeId = 4,
                    TitleId = 3,
                }
            });
        }
    }
}