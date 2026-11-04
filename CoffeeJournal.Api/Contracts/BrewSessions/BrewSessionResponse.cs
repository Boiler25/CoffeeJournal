namespace CoffeeJournal.Api.Contracts.BrewSessions;

public sealed record BrewSessionResponse(
    Guid Id,
    Guid UserId,
    Guid CoffeeBagId,
    Guid RecipeId,
    Guid? GrinderId,
    DateTime BrewedAt,
    string? GrindSize,
    int? Sweetness,
    int? Acidity,
    int? Bitterness,
    string? FlavorNotes,
    string? Notes,
    string? NextTimeNotes);