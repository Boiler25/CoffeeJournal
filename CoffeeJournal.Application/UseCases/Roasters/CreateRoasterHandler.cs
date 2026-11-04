using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.UseCases.Roasters;

public sealed class CreateRoasterHandler
{
    private readonly IRoasterRepository _repository;

    public CreateRoasterHandler(IRoasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(
        CreateRoasterCommand command,
        CancellationToken cancellationToken = default)
    {
        var roaster = new Roaster(
            name: command.Name,
            country: command.Country,
            website: command.Website);

        await _repository.AddAsync(roaster, cancellationToken);

        return roaster.Id;
    }
}