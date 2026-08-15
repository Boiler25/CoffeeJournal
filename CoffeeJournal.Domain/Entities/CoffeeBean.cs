using CoffeeJournal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeJournal.Domain.Entities;
public class CoffeeBean
{
    // Для EF Core
    private CoffeeBean()
    {
    }

    public CoffeeBean(
        Guid roasterId,
        string name,
        string? region = null,
        string? process = null,
        RoastLevel? roastLevel = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Coffee name cannot be empty.", nameof(name));
        if (roasterId == Guid.Empty)
            throw new ArgumentException(
                "Roaster id cannot be empty.",
                nameof(roasterId));

        Id = Guid.CreateVersion7();
        RoasterId = roasterId;
        Name = name.Trim();
        Region = region?.Trim();
        Process = process?.Trim();
        RoastLevel = roastLevel;
    }

    public Guid Id { get; private set; }

    public Guid RoasterId { get; private set; }

    public string Name { get; private set; }

    public string? Region { get; private set; }

    public string? Process { get; private set; }

    public RoastLevel? RoastLevel { get; private set; }

    // Навигационное свойство
    public Roaster Roaster { get; private set; } = null!;

}
