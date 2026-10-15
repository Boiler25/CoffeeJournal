using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.HasMany(user => user.CoffeeBags)
            .WithOne(coffeeBag => coffeeBag.User)
            .HasForeignKey(coffeeBag => coffeeBag.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(user => user.Recipes)
            .WithOne(recipe => recipe.User)
            .HasForeignKey(recipe => recipe.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(user => user.Grinders)
            .WithOne(grinder => grinder.User)
            .HasForeignKey(grinder => grinder.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(user => user.BrewSessions)
            .WithOne(session => session.User)
            .HasForeignKey(session => session.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}