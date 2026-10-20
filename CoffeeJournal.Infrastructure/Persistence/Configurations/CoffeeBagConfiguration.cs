using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class CoffeeBagConfiguration : IEntityTypeConfiguration<CoffeeBag>
{
    public void Configure(EntityTypeBuilder<CoffeeBag> builder)
    {
        builder.ToTable("coffee_bags", table =>
        {
            table.HasCheckConstraint(
                "CK_coffee_bags_weight_positive",
                "\"Weight\" > 0");
        });

        builder.HasKey(bag => bag.Id);

        builder.Property(bag => bag.Id).IsRequired();
        builder.Property(bag => bag.UserId).IsRequired();
        builder.Property(bag => bag.CoffeeBeanId).IsRequired();
        builder.Property(bag => bag.Weight).IsRequired();
        builder.Property(bag => bag.PurchaseDate).IsRequired();
        builder.Property(bag => bag.RoastDate);
        builder.Property(bag => bag.OpenedDate);
        builder.Property(bag => bag.FinishedDate);
        builder.Property(bag => bag.Notes).HasMaxLength(1000);

        builder.HasOne(bag => bag.User)
            .WithMany(user => user.CoffeeBags)
            .HasForeignKey(bag => bag.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bag => bag.CoffeeBean)
            .WithMany()
            .HasForeignKey(bag => bag.CoffeeBeanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}