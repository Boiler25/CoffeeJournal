using CoffeeJournal.Application.UseCases.BrewSessions;
using CoffeeJournal.Tests.Fakes;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Tests;

public class CreateBrewSessionHandlerTests
{
    [Fact]
    public async Task HandleAsync_ValidCommand_SavesSession()
    {
        // Arrange
        var repository = new FakeBrewSessionRepository();
        var handler = new CreateBrewSessionHandler(repository);

        var command = new CreateBrewSessionCommand(
            UserId: Guid.NewGuid(),
            CoffeeBagId: Guid.NewGuid(),
            RecipeId: Guid.NewGuid(),
            BrewedAt: DateTime.UtcNow.AddMinutes(-5),
            Sweetness: 4,
            Acidity: 3,
            Bitterness: 2,
            FlavorNotes: "Chocolate, caramel");

        // Act
        var sessionId = await handler.HandleAsync(command);

        // Assert
        var session = Assert.Single(repository.Sessions);

        Assert.Equal(sessionId, session.Id);
        Assert.Equal(command.UserId, session.UserId);
        Assert.Equal(command.CoffeeBagId, session.CoffeeBagId);
        Assert.Equal(command.RecipeId, session.RecipeId);
        Assert.Equal(command.Sweetness, session.Sweetness);
        Assert.Equal(command.Acidity, session.Acidity);
        Assert.Equal(command.Bitterness, session.Bitterness);
        Assert.Equal(command.FlavorNotes, session.FlavorNotes);
    }

    [Fact]
    public async Task HandleAsync_ValidCommand_ReturnsCreatedSessionId()
    {
        // Arrange
        var repository = new FakeBrewSessionRepository();
        var handler = new CreateBrewSessionHandler(repository);

        var command = new CreateBrewSessionCommand(
            UserId: Guid.NewGuid(),
            CoffeeBagId: Guid.NewGuid(),
            RecipeId: Guid.NewGuid(),
            BrewedAt: DateTime.UtcNow.AddMinutes(-5));

        // Act
        var sessionId = await handler.HandleAsync(command);

        // Assert
        Assert.NotEqual(Guid.Empty, sessionId);
        Assert.Equal(sessionId, Assert.Single(repository.Sessions).Id);
    }
}