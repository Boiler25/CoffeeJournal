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

        return Results.Ok(sessions);
    }
}