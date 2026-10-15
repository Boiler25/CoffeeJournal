using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(recipe => recipe.Id);

        builder.Property(recipe => recipe.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(recipe => recipe.BrewingMethod)
            .IsRequired();

        builder.Property(recipe => recipe.CoffeeDose)
            .IsRequired();

        builder.Property(recipe => recipe.WaterAmount)
            .IsRequired();

        builder.Property(recipe => recipe.Temperature)
            .IsRequired(false);

        builder.Property(recipe => recipe.BloomWater)
            .IsRequired(false);

        builder.Property(recipe => recipe.BloomTime)
            .IsRequired(false);

        builder.Property(recipe => recipe.Description)
            .HasMaxLength(2000);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Recipes_CoffeeDose",
                "\"CoffeeDose\" > 0");

            table.HasCheckConstraint(
                "CK_Recipes_WaterAmount",
                "\"WaterAmount\" > 0");
        });

        builder.HasOne(recipe => recipe.User)
            .WithMany(user => user.Recipes)
            .HasForeignKey(recipe => recipe.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(recipe => recipe.UserId);
    }
}