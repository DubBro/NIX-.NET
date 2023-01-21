using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR3.Entities.Instances;

namespace Module4PR3.Entities.Configs
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.DateOfBirth).HasColumnType("date").IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(15).IsRequired(false);
            builder.Property(a => a.Email).HasMaxLength(255).IsRequired(false);
            builder.Property(a => a.InstagramUrl).HasMaxLength(255).IsRequired(false);

            builder.HasMany(a => a.ArtistSongs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Artist>()
            {
                new Artist() { Id = 1, Name = "Skrillex", DateOfBirth = new DateTime(1988, 1, 15), InstagramUrl = "https://www.instagram.com/skrillex/" },
                new Artist() { Id = 2, Name = "Bob Marley", DateOfBirth = new DateTime(1945, 2, 6) },
                new Artist() { Id = 3, Name = "Damian Marley", DateOfBirth = new DateTime(1978, 7, 21) },
                new Artist() { Id = 4, Name = "Eminem", DateOfBirth = new DateTime(1972, 10, 17), InstagramUrl = "https://www.instagram.com/eminem/" },
                new Artist() { Id = 5, Name = "Netsky", DateOfBirth = new DateTime(1989, 3, 22), InstagramUrl = "https://www.instagram.com/netskyofficial/" },
                new Artist() { Id = 6, Name = "Ludwig van Beethoven", DateOfBirth = new DateTime(1770, 12, 17) },
                new Artist() { Id = 7, Name = "AC-DC", DateOfBirth = new DateTime(1973, 12, 1), InstagramUrl = "https://www.instagram.com/acdc/" },
            });
        }
    }
}
