using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.UseCases.BrewSessions;

public sealed class GetBrewSessionsHandler
{
    private readonly IBrewSessionRepository _repository;

    public GetBrewSessionsHandler(IBrewSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<BrewSession>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}