using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class RoasterConfiguration : IEntityTypeConfiguration<Roaster>
{
    public void Configure(EntityTypeBuilder<Roaster> builder)
    {
        builder.HasKey(roaster => roaster.Id);

        builder.Property(roaster => roaster.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(roaster => roaster.Country)
            .HasMaxLength(100);

        builder.Property(roaster => roaster.Website)
            .HasMaxLength(2048);
    }
}