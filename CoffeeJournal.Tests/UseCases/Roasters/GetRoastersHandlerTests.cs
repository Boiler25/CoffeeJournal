using CoffeeJournal.Application.UseCases.Roasters;
using CoffeeJournal.Domain.Entities;
using CoffeeJournal.Tests.Fakes;

namespace CoffeeJournal.Tests.UseCases.Roasters;

public class GetRoastersHandlerTests
{
    [Fact]
    public async Task HandleAsync_ReturnsAllRoasters()
    {
        // Arrange
        var repository = new FakeRoasterRepository();

        var firstRoaster = new Roaster(
            name: "Tasty Coffee",
            country: "Russia");

        var secondRoaster = new Roaster(
            name: "The Barn",
            country: "Germany");

        repository.Roasters.Add(firstRoaster);
        repository.Roasters.Add(secondRoaster);

        var handler = new GetRoastersHandler(repository);

        // Act
        var result = await handler.HandleAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(firstRoaster, result);
        Assert.Contains(secondRoaster, result);
    }

    [Fact]
    public async Task HandleAsync_WhenNoRoastersExist_ReturnsEmptyList()
    {
        // Arrange
        var repository = new FakeRoasterRepository();
        var handler = new GetRoastersHandler(repository);

        // Act
        var result = await handler.HandleAsync();

        // Assert
        Assert.Empty(result);
    }
}