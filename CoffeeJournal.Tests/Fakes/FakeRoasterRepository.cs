using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Tests.Fakes;

public sealed class FakeRoasterRepository : IRoasterRepository
{
    public List<Roaster> Roasters { get; } = [];

    public Task AddAsync(
        Roaster roaster,
        CancellationToken cancellationToken = default)
    {
        Roasters.Add(roaster);
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Roaster>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Roaster> roasters = Roasters;
        return Task.FromResult(roasters);
    }
}