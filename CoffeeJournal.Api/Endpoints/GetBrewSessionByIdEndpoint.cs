using CoffeeJournal.Api.Contracts.BrewSessions;
using CoffeeJournal.Api.Mappings;
using CoffeeJournal.Application.UseCases.BrewSessions;

namespace CoffeeJournal.Api.Endpoints;

public sealed class GetBrewSessionByIdEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        endpointsBuilder
            .MapGet("/brew-sessions/{id:guid}", HandleAsync)
            .WithTags("Brew Sessions")
            .WithSummary("Get a brew session by ID.");
    }

    private static async Task<IResult> HandleAsync(
        Guid id,
        GetBrewSessionByIdHandler handler,
        CancellationToken cancellationToken)
    {
        var session = await handler.HandleAsync(
            id,
            cancellationToken);

        if (session is null)
        {
            return Results.NotFound();
        }

        var response = session.ToResponse();

        return Results.Ok(response);
    }
}