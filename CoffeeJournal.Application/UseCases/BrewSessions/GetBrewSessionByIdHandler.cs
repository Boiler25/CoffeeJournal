using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.UseCases.BrewSessions;

public sealed class GetBrewSessionByIdHandler
{
    private readonly IBrewSessionRepository _repository;

    public GetBrewSessionByIdHandler(
        IBrewSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<BrewSession?> HandleAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(
            id,
            cancellationToken);
    }
}