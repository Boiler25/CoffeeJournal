using CoffeeJournal.Api.Contracts.BrewSessions;
using CoffeeJournal.Application.UseCases.BrewSessions;

namespace CoffeeJournal.Api.Endpoints;

public sealed class CreateBrewSessionEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        endpointsBuilder
            .MapPost("/brew-sessions", HandleAsync)
            .WithTags("Brew Sessions")
            .WithSummary("Create a brew session.");
    }

    private static async Task<IResult> HandleAsync(
        CreateBrewSessionRequest request,
        CreateBrewSessionHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new CreateBrewSessionCommand(
            UserId: request.UserId,
            CoffeeBagId: request.CoffeeBagId,
            RecipeId: request.RecipeId,
            BrewedAt: request.BrewedAt,
            GrinderId: request.GrinderId,
            GrindSize: request.GrindSize,
            Sweetness: request.Sweetness,
            Acidity: request.Acidity,
            Bitterness: request.Bitterness,
            FlavorNotes: request.FlavorNotes,
            Notes: request.Notes,
            NextTimeNotes: request.NextTimeNotes);

        var sessionId = await handler.HandleAsync(
            command,
            cancellationToken);

        return Results.Created(
            $"/api/brew-sessions/{sessionId}",
            new { id = sessionId });
    }
}