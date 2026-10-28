namespace CoffeeJournal.Application.UseCases.BrewSessions;

public sealed record CreateBrewSessionCommand(
    Guid UserId,
    Guid CoffeeBagId,
    Guid RecipeId,
    DateTime BrewedAt,
    Guid? GrinderId = null,
    string? GrindSize = null,
    int? Sweetness = null,
    int? Acidity = null,
    int? Bitterness = null,
    string? FlavorNotes = null,
    string? Notes = null,
    string? NextTimeNotes = null);