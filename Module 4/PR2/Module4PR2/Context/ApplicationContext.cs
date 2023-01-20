using Microsoft.EntityFrameworkCore;
using Module4PR2.Entities.Configs;
using Module4PR2.Entities.Instances;
using Microsoft.Extensions.Configuration;

namespace Module4PR2.Context
{
    public class ApplicationContext : DbContext
    {
        private string? _connection;

        public ApplicationContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            _connection = config.GetConnectionString("DefaultConnection");
        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Office>? Offices { get; set; }
        public DbSet<Title>? Titles { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<EmployeeProject>? EmployeeProjects { get; set; }
        public DbSet<Client>? Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}