namespace CoffeeJournal.Api.Contracts.Roasters;

public sealed record RoasterResponse(
    Guid Id,
    string Name,
    string? Country,
    string? Website);