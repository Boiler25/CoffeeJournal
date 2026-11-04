using CoffeeJournal.Api.Contracts.BrewSessions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Api.Mappings;

public static class BrewSessionMappings
{
    public static BrewSessionResponse ToResponse(
        this BrewSession session)
    {
        return new BrewSessionResponse(
            Id: session.Id,
            UserId: session.UserId,
            CoffeeBagId: session.CoffeeBagId,
            RecipeId: session.RecipeId,
            GrinderId: session.GrinderId,
            BrewedAt: session.BrewedAt,
            GrindSize: session.GrindSize,
            Sweetness: session.Sweetness,
            Acidity: session.Acidity,
            Bitterness: session.Bitterness,
            FlavorNotes: session.FlavorNotes,
            Notes: session.Notes,
            NextTimeNotes: session.NextTimeNotes);
    }
}