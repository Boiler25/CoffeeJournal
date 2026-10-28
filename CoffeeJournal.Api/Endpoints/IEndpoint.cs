namespace CoffeeJournal.Api.Endpoints;

public interface IEndpoint
{
    void Register(IEndpointRouteBuilder endpointsBuilder);
}