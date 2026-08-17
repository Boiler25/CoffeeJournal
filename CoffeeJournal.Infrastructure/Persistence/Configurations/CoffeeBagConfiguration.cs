using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class CoffeeBagConfiguration
    : IEntityTypeConfiguration<CoffeeBag>
{
    public void Configure(
        EntityTypeBuilder<CoffeeBag> builder)
    {
        builder.ToTable("coffee_bags");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CoffeeBeanId)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.PurchaseDate)
            .IsRequired();

        builder.Property(x => x.RoastDate);

        builder.Property(x => x.OpenedDate);

        builder.Property(x => x.FinishedDate);

        builder.Property(x => x.Notes)
            .HasMaxLength(1000);

        builder.HasOne(x => x.User)
            .WithMany(x => x.CoffeeBags)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.CoffeeBean)
            .WithMany()
            .HasForeignKey(x => x.CoffeeBeanId);

        builder.HasMany(x => x.BrewSessions)
            .WithOne(x => x.CoffeeBag)
            .HasForeignKey(x => x.CoffeeBagId);
    }
}