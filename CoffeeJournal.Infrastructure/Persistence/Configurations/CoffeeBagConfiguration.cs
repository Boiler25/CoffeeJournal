using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class CoffeeBagConfiguration
    : IEntityTypeConfiguration<CoffeeBag>
{
    public void Configure(EntityTypeBuilder<CoffeeBag> builder)
    {
        builder.ToTable("coffee_bags");

        builder.HasKey(coffeeBag => coffeeBag.Id);

        builder.Property(coffeeBag => coffeeBag.UserId)
            .IsRequired();

        builder.Property(coffeeBag => coffeeBag.CoffeeBeanId)
            .IsRequired();

        builder.Property(coffeeBag => coffeeBag.Weight)
            .IsRequired();

        builder.Property(coffeeBag => coffeeBag.PurchaseDate)
            .IsRequired();

        builder.Property(coffeeBag => coffeeBag.RoastDate)
            .IsRequired(false);

        builder.Property(coffeeBag => coffeeBag.OpenedDate)
            .IsRequired(false);

        builder.Property(coffeeBag => coffeeBag.FinishedDate)
            .IsRequired(false);

        builder.Property(coffeeBag => coffeeBag.Notes)
            .HasMaxLength(1000);

        builder.HasOne(coffeeBag => coffeeBag.User)
            .WithMany(user => user.CoffeeBags)
            .HasForeignKey(coffeeBag => coffeeBag.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(coffeeBag => coffeeBag.CoffeeBean)
            .WithMany()
            .HasForeignKey(coffeeBag => coffeeBag.CoffeeBeanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(coffeeBag => coffeeBag.BrewSessions)
            .WithOne(session => session.CoffeeBag)
            .HasForeignKey(session => session.CoffeeBagId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}