namespace CoffeeJournal.Application.UseCases.Roasters;

public sealed record CreateRoasterCommand(
    string Name,
    string? Country = null,
    string? Website = null);