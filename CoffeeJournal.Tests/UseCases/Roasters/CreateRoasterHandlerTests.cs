using CoffeeJournal.Application.UseCases.Roasters;
using CoffeeJournal.Tests.Fakes;

namespace CoffeeJournal.Tests.UseCases.Roasters;

public class CreateRoasterHandlerTests
{
    [Fact]
    public async Task HandleAsync_CreatesRoasterAndReturnsId()
    {
        // Arrange
        var repository = new FakeRoasterRepository();
        var handler = new CreateRoasterHandler(repository);

        var command = new CreateRoasterCommand(
            Name: "Tasty Coffee",
            Country: "Russia",
            Website: "https://shop.tastycoffee.ru");

        // Act
        var result = await handler.HandleAsync(command);

        // Assert
        var roaster = Assert.Single(repository.Roasters);

        Assert.Equal(roaster.Id, result);
        Assert.Equal("Tasty Coffee", roaster.Name);
        Assert.Equal("Russia", roaster.Country);
        Assert.Equal("https://shop.tastycoffee.ru", roaster.Website);
    }
}