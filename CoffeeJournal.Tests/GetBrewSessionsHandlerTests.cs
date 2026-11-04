using CoffeeJournal.Application.UseCases.BrewSessions;
using CoffeeJournal.Domain.Entities;
using CoffeeJournal.Tests.Fakes;

namespace CoffeeJournal.Tests;

public class GetBrewSessionsHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenSessionsExist_ReturnsAllSessions()
    {
        // Arrange
        var repository = new FakeBrewSessionRepository();

        var firstSession = CreateBrewSession();
        var secondSession = CreateBrewSession();

        repository.Sessions.Add(firstSession);
        repository.Sessions.Add(secondSession);

        var handler = new GetBrewSessionsHandler(repository);

        // Act
        var result = await handler.HandleAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Same(firstSession, result[0]);
        Assert.Same(secondSession, result[1]);
    }

    [Fact]
    public async Task HandleAsync_WhenNoSessionsExist_ReturnsEmptyList()
    {
        // Arrange
        var repository = new FakeBrewSessionRepository();
        var handler = new GetBrewSessionsHandler(repository);

        // Act
        var result = await handler.HandleAsync();

        // Assert
        Assert.Empty(result);
    }

    private static BrewSession CreateBrewSession()
    {
        return new BrewSession(
            userId: Guid.NewGuid(),
            coffeeBagId: Guid.NewGuid(),
            recipeId: Guid.NewGuid(),
            brewedAt: DateTime.UtcNow.AddMinutes(-5));
    }
}