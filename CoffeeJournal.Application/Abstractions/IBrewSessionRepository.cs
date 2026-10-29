using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.Abstractions;

public interface IBrewSessionRepository
{
    Task AddAsync(
        BrewSession session,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<BrewSession>> GetAllAsync(
        CancellationToken cancellationToken = default);
}