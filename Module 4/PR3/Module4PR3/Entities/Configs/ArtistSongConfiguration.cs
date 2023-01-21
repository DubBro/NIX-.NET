using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR3.Entities.Instances;

namespace Module4PR3.Entities.Configs
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong");
            builder.HasKey(a => new { a.ArtistId, a.SongId });

            builder.HasOne(s => s.Artist)
                .WithMany(a => a.ArtistSongs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(a => a.Song)
                .WithMany(s => s.ArtistSongs)
                .HasForeignKey(a => a.SongId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<ArtistSong>()
            {
                new ArtistSong() { ArtistId = 1, SongId = 1 },
                new ArtistSong() { ArtistId = 1, SongId = 2 },
                new ArtistSong() { ArtistId = 1, SongId = 3 },
                new ArtistSong() { ArtistId = 2, SongId = 4 },
                new ArtistSong() { ArtistId = 3, SongId = 5 },
                new ArtistSong() { ArtistId = 3, SongId = 3 },
                new ArtistSong() { ArtistId = 4, SongId = 6 },
                new ArtistSong() { ArtistId = 4, SongId = 7 },
                new ArtistSong() { ArtistId = 4, SongId = 8 },
                new ArtistSong() { ArtistId = 5, SongId = 9 },
                new ArtistSong() { ArtistId = 5, SongId = 10 },
                new ArtistSong() { ArtistId = 6, SongId = 11 },
                new ArtistSong() { ArtistId = 7, SongId = 12 },
            });
        }
    }
}
