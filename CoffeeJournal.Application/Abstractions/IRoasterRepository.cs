using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.Abstractions;

public interface IRoasterRepository
{
    Task AddAsync(
        Roaster roaster,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Roaster>> GetAllAsync(
        CancellationToken cancellationToken = default);
}