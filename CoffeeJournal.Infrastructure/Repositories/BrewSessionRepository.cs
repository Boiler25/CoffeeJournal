using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;
using CoffeeJournal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeJournal.Infrastructure.Repositories;

public sealed class BrewSessionRepository : IBrewSessionRepository
{
    private readonly CoffeeJournalDbContext _dbContext;

    public BrewSessionRepository(CoffeeJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        BrewSession session,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.BrewSessions.AddAsync(
            session,
            cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}