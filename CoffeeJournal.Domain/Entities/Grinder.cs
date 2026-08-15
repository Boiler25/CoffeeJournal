using CoffeeJournal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeJournal.Domain.Entities;

public class Grinder
{
    private Grinder()
    {
    }

    public Grinder(
        Guid userId,
        string name,
        string? manufacturer = null,
        BurrType? burrType = null,
        string? notes = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(
                "User id cannot be empty.",
                nameof(userId));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Grinder name cannot be empty.",
                nameof(name));

        Id = Guid.CreateVersion7();

        UserId = userId;

        Name = name.Trim();

        Manufacturer = manufacturer?.Trim();

        BurrType = burrType;

        Notes = notes?.Trim();
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Name { get; private set; }

    public string? Manufacturer { get; private set; }

    public BurrType? BurrType { get; private set; }

    public string? Notes { get; private set; }

    public User User { get; private set; } = null!;

    public ICollection<BrewSession> BrewSessions { get; private set; }
        = new List<BrewSession>();
}
