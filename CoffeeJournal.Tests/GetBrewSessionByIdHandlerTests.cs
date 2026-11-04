
using CoffeeJournal.Application.UseCases.BrewSessions;
using CoffeeJournal.Domain.Entities;
using CoffeeJournal.Tests.Fakes;

namespace CoffeeJournal.Tests.UseCases.BrewSessions;

public class GetBrewSessionByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenSessionExists_ReturnsSession()
    {
        // Arrange
        var repository = new FakeBrewSessionRepository();
        var session = CreateBrewSession();

        repository.Sessions.Add(session);

        var handler = new GetBrewSessionByIdHandler(repository);

        // Act
        var result = await handler.HandleAsync(session.Id);

        // Assert
        Assert.Same(session, result);
    }

    [Fact]
    public async Task HandleAsync_WhenSessionDoesNotExist_ReturnsNull()
    {
        // Arrange
        var repository = new FakeBrewSessionRepository();
        var handler = new GetBrewSessionByIdHandler(repository);

        // Act
        var result = await handler.HandleAsync(Guid.NewGuid());

        // Assert
        Assert.Null(result);
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
