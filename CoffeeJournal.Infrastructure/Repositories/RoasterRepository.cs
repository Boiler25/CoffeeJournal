using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;
using CoffeeJournal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeJournal.Infrastructure.Repositories;

public sealed class RoasterRepository : IRoasterRepository
{
    private readonly CoffeeJournalDbContext _dbContext;

    public RoasterRepository(CoffeeJournalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        Roaster roaster,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Roasters.AddAsync(roaster, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Roaster>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roasters
            .AsNoTracking()
            .OrderBy(roaster => roaster.Name)
            .ToListAsync(cancellationToken);
    }
}