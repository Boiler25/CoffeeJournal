using CoffeeJournal.Api.Mappings;
using CoffeeJournal.Application.UseCases.Roasters;

namespace CoffeeJournal.Api.Endpoints.Roasters;

public sealed class GetRoastersEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        endpointsBuilder
            .MapGet("/roasters", HandleAsync)
            .WithTags("Roasters")
            .WithSummary("Get all roasters.");
    }

    private static async Task<IResult> HandleAsync(
        GetRoastersHandler handler,
        CancellationToken cancellationToken)
    {
        var roasters = await handler.HandleAsync(cancellationToken);

        var response = roasters
            .Select(roaster => roaster.ToResponse())
            .ToList();

        return Results.Ok(response);
    }
}