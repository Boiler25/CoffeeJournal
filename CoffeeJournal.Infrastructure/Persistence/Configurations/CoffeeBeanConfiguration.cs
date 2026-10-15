using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeJournal.Infrastructure.Persistence.Configurations;

public class CoffeeBeanConfiguration : IEntityTypeConfiguration<CoffeeBean>
{
    public void Configure(EntityTypeBuilder<CoffeeBean> builder)
    {
        builder.HasKey(coffeeBean => coffeeBean.Id);

        builder.Property(coffeeBean => coffeeBean.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(coffeeBean => coffeeBean.Region)
            .HasMaxLength(150);

        builder.Property(coffeeBean => coffeeBean.Process)
            .HasMaxLength(100);

        builder.Property(coffeeBean => coffeeBean.RoastLevel)
            .IsRequired(false);

        builder.HasOne(coffeeBean => coffeeBean.Roaster)
            .WithMany(roaster => roaster.CoffeeBeans)
            .HasForeignKey(coffeeBean => coffeeBean.RoasterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(coffeeBean => coffeeBean.RoasterId);
    }
}