namespace CoffeeJournal.Api.Endpoints;

public static class EndpointsProvider
{
    public static void RegisterAppEndpoints(
        RouteGroupBuilder endpointsBuilder)
    {
        endpointsBuilder.Register<CreateBrewSessionEndpoint>();
        endpointsBuilder.Register<GetBrewSessionsEndpoint>();
    }
}