using CoffeeJournal.Api.Contracts.Roasters;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Api.Mappings;

public static class RoasterMappings
{
    public static RoasterResponse ToResponse(this Roaster roaster)
    {
        return new RoasterResponse(
            Id: roaster.Id,
            Name: roaster.Name,
            Country: roaster.Country,
            Website: roaster.Website);
    }
}