using CoffeeJournal.Api.Contracts.Roasters;
using CoffeeJournal.Application.UseCases.Roasters;

namespace CoffeeJournal.Api.Endpoints.Roasters;

public sealed class CreateRoasterEndpoint : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        endpointsBuilder
            .MapPost("/roasters", HandleAsync)
            .WithTags("Roasters")
            .WithSummary("Create a roaster.");
    }

    private static async Task<IResult> HandleAsync(
        CreateRoasterRequest request,
        CreateRoasterHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new CreateRoasterCommand(
            Name: request.Name,
            Country: request.Country,
            Website: request.Website);

        var roasterId = await handler.HandleAsync(
            command,
            cancellationToken);

        return Results.Created(
            $"/api/roasters/{roasterId}",
            new { id = roasterId });
    }
}