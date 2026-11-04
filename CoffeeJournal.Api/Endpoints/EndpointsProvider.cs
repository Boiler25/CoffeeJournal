using CoffeeJournal.Api.Endpoints.Roasters;

namespace CoffeeJournal.Api.Endpoints;

public static class EndpointsProvider
{
    public static void RegisterAppEndpoints(
        RouteGroupBuilder endpointsBuilder)
    {
        endpointsBuilder.Register<CreateBrewSessionEndpoint>();
        endpointsBuilder.Register<GetBrewSessionsEndpoint>();
        endpointsBuilder.Register<GetBrewSessionByIdEndpoint>();

        endpointsBuilder.Register<CreateRoasterEndpoint>();
        endpointsBuilder.Register<GetRoastersEndpoint>();
    }
}