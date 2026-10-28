
using CoffeeJournal.Api.Contracts.BrewSessions;
using CoffeeJournal.Application.UseCases.BrewSessions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace CoffeeJournal.Api.Endpoints;

public static class BrewSessionEndpoints
{
    public static IEndpointRouteBuilder MapBrewSessionEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/brew-sessions",
            async (
                CreateBrewSessionRequest request,
                CreateBrewSessionHandler handler,
                CancellationToken cancellationToken) =>
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
            });

        return app;
    }
}
