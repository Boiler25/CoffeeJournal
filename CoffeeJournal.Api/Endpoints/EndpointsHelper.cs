namespace CoffeeJournal.Api.Endpoints;

public static class EndpointsHelper
{
    public static IEndpointRouteBuilder Register<T>(
        this IEndpointRouteBuilder endpointsBuilder)
        where T : IEndpoint, new()
    {
        var endpoint = new T();
        endpoint.Register(endpointsBuilder);

        return endpointsBuilder;
    }
}