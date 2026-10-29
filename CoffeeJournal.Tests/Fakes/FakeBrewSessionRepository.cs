using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Tests.Fakes;

public sealed class FakeBrewSessionRepository : IBrewSessionRepository
{
    public List<BrewSession> Sessions { get; } = [];

    public Task AddAsync(
        BrewSession session,
        CancellationToken cancellationToken = default)
    {
        Sessions.Add(session);

        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<BrewSession>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<BrewSession> sessions = Sessions;

        return Task.FromResult(sessions);
    }
}