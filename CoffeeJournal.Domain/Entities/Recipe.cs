using CoffeeJournal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeJournal.Domain.Entities;

public class Recipe
{
    private Recipe()
    {
    }

    public Recipe(
        Guid userId,
        string name,
        BrewingMethod brewingMethod,
        double coffeeDose,
        double waterAmount,
        double? temperature = null,
        double? bloomWater = null,
        TimeSpan? bloomTime = null,
        string? description = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(
                "User id cannot be empty.",
                nameof(userId));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Recipe name cannot be empty.",
                nameof(name));

        if (coffeeDose <= 0)
            throw new ArgumentException(
                "Coffee dose must be greater than zero.",
                nameof(coffeeDose));

        if (waterAmount <= 0)
            throw new ArgumentException(
                "Water amount must be greater than zero.",
                nameof(waterAmount));

        Id = Guid.CreateVersion7();

        UserId = userId;

        Name = name.Trim();

        BrewingMethod = brewingMethod;

        CoffeeDose = coffeeDose;

        WaterAmount = waterAmount;

        Temperature = temperature;

        BloomWater = bloomWater;

        BloomTime = bloomTime;

        Description = description?.Trim();
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Name { get; private set; }

    public BrewingMethod BrewingMethod { get; private set; }

    public double CoffeeDose { get; private set; }

    public double WaterAmount { get; private set; }

    public double? Temperature { get; private set; }

    public double? BloomWater { get; private set; }

    public TimeSpan? BloomTime { get; private set; }

    public string? Description { get; private set; }

    public User User { get; private set; } = null!;

    public ICollection<BrewSession> BrewSessions { get; private set; }
        = new List<BrewSession>();
}
