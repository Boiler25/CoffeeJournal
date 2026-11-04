namespace CoffeeJournal.Api.Contracts.Roasters;

public sealed record CreateRoasterRequest(
    string Name,
    string? Country,
    string? Website);