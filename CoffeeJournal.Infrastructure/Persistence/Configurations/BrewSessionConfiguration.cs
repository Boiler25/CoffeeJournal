
using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class BrewSessionConfiguration
    : IEntityTypeConfiguration<BrewSession>
{
    public void Configure(EntityTypeBuilder<BrewSession> builder)
    {
        builder.ToTable("brew_sessions", table =>
        {
            table.HasCheckConstraint(
                "CK_brew_sessions_sweetness",
                "\"Sweetness\" IS NULL OR \"Sweetness\" BETWEEN 1 AND 5");

            table.HasCheckConstraint(
                "CK_brew_sessions_acidity",
                "\"Acidity\" IS NULL OR \"Acidity\" BETWEEN 1 AND 5");

            table.HasCheckConstraint(
                "CK_brew_sessions_bitterness",
                "\"Bitterness\" IS NULL OR \"Bitterness\" BETWEEN 1 AND 5");
        });

        builder.HasKey(session => session.Id);

        builder.Property(session => session.BrewedAt)
            .IsRequired();

        builder.Property(session => session.GrindSize)
            .HasMaxLength(100);

        builder.Property(session => session.Sweetness)
            .IsRequired(false);

        builder.Property(session => session.Acidity)
            .IsRequired(false);

        builder.Property(session => session.Bitterness)
            .IsRequired(false);

        builder.Property(session => session.FlavorNotes)
            .HasMaxLength(1000);

        builder.Property(session => session.Notes)
            .HasMaxLength(2000);

        builder.Property(session => session.NextTimeNotes)
            .HasMaxLength(2000);

        builder.HasOne(session => session.User)
            .WithMany(user => user.BrewSessions)
            .HasForeignKey(session => session.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(session => session.CoffeeBag)
            .WithMany(coffeeBag => coffeeBag.BrewSessions)
            .HasForeignKey(session => session.CoffeeBagId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(session => session.Recipe)
            .WithMany(recipe => recipe.BrewSessions)
            .HasForeignKey(session => session.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(session => session.Grinder)
            .WithMany(grinder => grinder.BrewSessions)
            .HasForeignKey(session => session.GrinderId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(session => session.UserId);
        builder.HasIndex(session => session.CoffeeBagId);
        builder.HasIndex(session => session.RecipeId);
        builder.HasIndex(session => session.GrinderId);
        builder.HasIndex(session => session.BrewedAt);
    }
}
