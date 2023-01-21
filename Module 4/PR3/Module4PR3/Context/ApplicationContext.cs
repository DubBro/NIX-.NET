using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4PR3.Entities.Configs;
using Module4PR3.Entities.Instances;

namespace Module4PR3.Context
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

        public DbSet<Artist>? Artists { get; set; }
        public DbSet<Song>? Songs { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<ArtistSong>? ArtistSongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArtistConfiguration());
            builder.ApplyConfiguration(new SongConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new ArtistSongConfiguration());
        }
    }
}
