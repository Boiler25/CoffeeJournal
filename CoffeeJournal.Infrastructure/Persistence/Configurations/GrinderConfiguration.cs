using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class GrinderConfiguration : IEntityTypeConfiguration<Grinder>
{
    public void Configure(EntityTypeBuilder<Grinder> builder)
    {
        builder.HasKey(grinder => grinder.Id);

        builder.Property(grinder => grinder.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(grinder => grinder.Manufacturer)
            .HasMaxLength(150);

        builder.Property(grinder => grinder.BurrType)
            .IsRequired(false);

        builder.Property(grinder => grinder.Notes)
            .HasMaxLength(2000);

        builder.HasOne(grinder => grinder.User)
            .WithMany(user => user.Grinders)
            .HasForeignKey(grinder => grinder.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(grinder => grinder.UserId);
    }
}