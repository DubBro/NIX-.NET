using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR3.Entities.Instances;

namespace Module4PR3.Entities.Configs
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            builder.Property(g => g.Title).HasMaxLength(50).IsRequired();

            builder.HasMany(g => g.Songs)
                .WithOne(s => s.Genre)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Genre>()
            {
                new Genre() { Id = 1, Title = "Dubstep" },
                new Genre() { Id = 2, Title = "Rap" },
                new Genre() { Id = 3, Title = "Rock" },
                new Genre() { Id = 4, Title = "Classic" },
                new Genre() { Id = 5, Title = "DrumNBass" },
                new Genre() { Id = 6, Title = "Reggae" },
            });
        }
    }
}
