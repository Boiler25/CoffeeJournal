using CoffeeJournal.Api.Contracts.BrewSessions;
using CoffeeJournal.Application.UseCases.BrewSessions;

namespace CoffeeJournal.Api.Endpoints;

public sealed class GetBrewSessionsEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        endpointsBuilder
            .MapGet("/brew-sessions", HandleAsync)
            .WithTags("Brew Sessions")
            .WithSummary("Get all brew sessions.");
    }

    private static async Task<IResult> HandleAsync(
        GetBrewSessionsHandler handler,
        CancellationToken cancellationToken)
    {
        var sessions = await handler.HandleAsync(cancellationToken);

        var response = sessions
            .Select(session => new BrewSessionResponse(
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
                NextTimeNotes: session.NextTimeNotes))
            .ToList();

        return Results.Ok(response);
    }
}