using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR3.Entities.Instances;

namespace Module4PR3.Entities.Configs
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Title).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Duration).HasColumnType("time").IsRequired();
            builder.Property(s => s.ReleasedDate).HasColumnType("date").IsRequired();

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.ArtistSongs)
                .WithOne(a => a.Song)
                .HasForeignKey(a => a.SongId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Song>()
            {
                new Song
                {
                    Id = 1,
                    Title = "Scary Monsters And Nice Sprites",
                    Duration = new TimeSpan(0, 4, 4),
                    ReleasedDate = new DateTime(2010, 10, 22),
                    GenreId = 1
                },
                new Song
                {
                    Id = 2,
                    Title = "First of the Year (Equinox)",
                    Duration = new TimeSpan(0, 4, 22),
                    ReleasedDate = new DateTime(2011, 6, 7),
                    GenreId = 1
                },
                new Song
                {
                    Id = 3,
                    Title = "Make It Bun Dem",
                    Duration = new TimeSpan(0, 3, 35),
                    ReleasedDate = new DateTime(2012, 5, 1),
                    GenreId = 1
                },
                new Song
                {
                    Id = 4,
                    Title = "Jamming",
                    Duration = new TimeSpan(0, 3, 31),
                    ReleasedDate = new DateTime(1977, 6, 3),
                    GenreId = 6
                },
                new Song
                {
                    Id = 5,
                    Title = "Welcome to Jamrock",
                    Duration = new TimeSpan(0, 3, 33),
                    ReleasedDate = new DateTime(2005, 3, 14),
                    GenreId = 6
                },
                new Song
                {
                    Id = 6,
                    Title = "Higher",
                    Duration = new TimeSpan(0, 3, 42),
                    ReleasedDate = new DateTime(2020, 12, 18),
                    GenreId = 2
                },
                new Song
                {
                    Id = 7,
                    Title = "The Real Slim Shady",
                    Duration = new TimeSpan(0, 4, 44),
                    ReleasedDate = new DateTime(2000, 5, 16),
                    GenreId = 2
                },
                new Song()
                {
                    Id = 8,
                    Title = "Under The Influence",
                    Duration = new TimeSpan(0, 5, 21),
                    ReleasedDate = new DateTime(2000, 5, 23),
                    GenreId = 2
                },
                new Song()
                {
                    Id = 9,
                    Title = "Your Way",
                    Duration = new TimeSpan(0, 5, 54),
                    ReleasedDate = new DateTime(2010, 2, 5),
                    GenreId = 5
                },
                new Song()
                {
                    Id = 10,
                    Title = "Detonate",
                    Duration = new TimeSpan(0, 3, 50),
                    ReleasedDate = new DateTime(2012, 6, 26),
                    GenreId = 5
                },
                new Song()
                {
                    Id = 11,
                    Title = "Moonlight Sonata (3rd Movement)",
                    Duration = new TimeSpan(0, 6, 52),
                    ReleasedDate = new DateTime(1802, 1, 1),
                    GenreId = 4
                },
                new Song()
                {
                    Id = 12,
                    Title = "Shot In The Dark",
                    Duration = new TimeSpan(0, 3, 6),
                    ReleasedDate = new DateTime(2020, 10, 7),
                    GenreId = 3
                },
            });
        }
    }
}
