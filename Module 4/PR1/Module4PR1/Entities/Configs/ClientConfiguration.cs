using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4PR1.Entities.Instances;

namespace Module4PR1.Entities.Configs
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(50).IsRequired(false);

            builder.HasMany(c => c.Projects)
                   .WithOne(p => p.Client)
                   .HasForeignKey(p => p.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Client>()
            {
                new Client() { ClientId = 1, FirstName = "Taras", LastName = "Melnyk", Email = "tarasmelnyk@pochta.tam" },
                new Client() { ClientId = 2, FirstName = "Igor", LastName = "Lopushko", Email = "igorlopushko@pochta.tut" },
                new Client() { ClientId = 3, FirstName = "Cristiano", LastName = "Ronaldo", Email = "ronaldo@cr7.siuuu", Phone = "07777777777" },
                new Client() { ClientId = 4, FirstName = "Henry", LastName = "Ford", Email = "ford@car.usa", Phone = "9852455792" },
                new Client() { ClientId = 5, FirstName = "Nikola", LastName = "Tesla", Email = "physics@invent.usa" },
            });
        }
    }
}
