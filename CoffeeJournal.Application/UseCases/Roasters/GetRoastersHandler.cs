using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.UseCases.Roasters;

public sealed class GetRoastersHandler
{
    private readonly IRoasterRepository _repository;

    public GetRoastersHandler(IRoasterRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Roaster>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}