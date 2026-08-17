using CoffeeJournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeJournal.Infrastructure.Persistence;

public class CoffeeJournalDbContext : DbContext
{
    public CoffeeJournalDbContext(
        DbContextOptions<CoffeeJournalDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Roaster> Roasters => Set<Roaster>();

    public DbSet<CoffeeBean> CoffeeBeans => Set<CoffeeBean>();

    public DbSet<CoffeeBag> CoffeeBags => Set<CoffeeBag>();

    public DbSet<Recipe> Recipes => Set<Recipe>();

    public DbSet<Grinder> Grinders => Set<Grinder>();

    public DbSet<BrewSession> BrewSessions => Set<BrewSession>();
}