using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeJournal.Domain.Entities;

public class CoffeeBag
{
    private CoffeeBag()
    {
    }

    public CoffeeBag(
        Guid userId,
        Guid coffeeBeanId,
        int weight,
        DateOnly purchaseDate,
        DateOnly? roastDate = null,
        string? notes = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(
                "User id cannot be empty.",
                nameof(userId));

        if (coffeeBeanId == Guid.Empty)
            throw new ArgumentException(
                "Coffee bean id cannot be empty.",
                nameof(coffeeBeanId));

        if (weight <= 0)
            throw new ArgumentException(
                "Weight must be greater than zero.",
                nameof(weight));

        Id = Guid.CreateVersion7();

        UserId = userId;
        CoffeeBeanId = coffeeBeanId;

        Weight = weight;

        PurchaseDate = purchaseDate;
        RoastDate = roastDate;

        Notes = notes?.Trim();
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Guid CoffeeBeanId { get; private set; }

    public int Weight { get; private set; }

    public DateOnly PurchaseDate { get; private set; }

    public DateOnly? RoastDate { get; private set; }

    public DateOnly? OpenedDate { get; private set; }

    public DateOnly? FinishedDate { get; private set; }

    public string? Notes { get; private set; }

    public User User { get; private set; } = null!;

    public CoffeeBean CoffeeBean { get; private set; } = null!;

    public ICollection<BrewSession> BrewSessions { get; private set; }
        = new List<BrewSession>();
}
