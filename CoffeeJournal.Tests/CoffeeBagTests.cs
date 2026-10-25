
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Tests.Domain;

public class CoffeeBagTests
{
    [Fact]
    public void Constructor_WithValidData_CreatesCoffeeBag()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var coffeeBeanId = Guid.NewGuid();
        var weight = 250;
        var purchaseDate = new DateOnly(2026, 10, 20);

        // Act
        var coffeeBag = new CoffeeBag(
            userId,
            coffeeBeanId,
            weight,
            purchaseDate);

        // Assert
        Assert.NotEqual(Guid.Empty, coffeeBag.Id);
        Assert.Equal(userId, coffeeBag.UserId);
        Assert.Equal(coffeeBeanId, coffeeBag.CoffeeBeanId);
        Assert.Equal(weight, coffeeBag.Weight);
        Assert.Equal(purchaseDate, coffeeBag.PurchaseDate);
    }

    [Fact]
    public void Constructor_WithEmptyUserId_ThrowsArgumentException()
    {
        // Arrange
        var coffeeBeanId = Guid.NewGuid();
        var purchaseDate = new DateOnly(2026, 10, 20);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new CoffeeBag(
                Guid.Empty,
                coffeeBeanId,
                250,
                purchaseDate));
    }

    [Fact]
    public void Constructor_WithZeroWeight_ThrowsArgumentException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var coffeeBeanId = Guid.NewGuid();
        var purchaseDate = new DateOnly(2026, 10, 20);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new CoffeeBag(
                userId,
                coffeeBeanId,
                0,
                purchaseDate));
    }

    [Fact]
    public void Open_WithValidDate_SetsOpenedDate()
    {
        // Arrange
        var coffeeBag = CreateCoffeeBag();
        var openedDate = new DateOnly(2026, 10, 22);

        // Act
        coffeeBag.Open(openedDate);

        // Assert
        Assert.Equal(openedDate, coffeeBag.OpenedDate);
    }

    [Fact]
    public void Open_WhenAlreadyOpened_ThrowsInvalidOperationException()
    {
        // Arrange
        var coffeeBag = CreateCoffeeBag();
        var openedDate = new DateOnly(2026, 10, 22);

        coffeeBag.Open(openedDate);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(
            () => coffeeBag.Open(openedDate.AddDays(1)));
    }

    [Fact]
    public void Finish_WhenNotOpened_ThrowsInvalidOperationException()
    {
        // Arrange
        var coffeeBag = CreateCoffeeBag();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(
            () => coffeeBag.Finish(new DateOnly(2026, 10, 23)));
    }

    [Fact]
    public void Finish_BeforeOpenedDate_ThrowsArgumentException()
    {
        // Arrange
        var coffeeBag = CreateCoffeeBag();
        var openedDate = new DateOnly(2026, 10, 22);

        coffeeBag.Open(openedDate);

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => coffeeBag.Finish(openedDate.AddDays(-1)));
    }

    private static CoffeeBag CreateCoffeeBag()
    {
        return new CoffeeBag(
            Guid.NewGuid(),
            Guid.NewGuid(),
            250,
            new DateOnly(2026, 10, 20));
    }

    [Theory]
    [InlineData(2026, 10, 19)]
    [InlineData(2026, 10, 18)]
    [InlineData(2025, 1, 1)]
    public void Open_BeforePurchaseDate_ThrowsArgumentException(
    int year,
    int month,
    int day)
    {
        // Arrange
        var coffeeBag = CreateCoffeeBag();
        var openedDate = new DateOnly(year, month, day);

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => coffeeBag.Open(openedDate));
    }

    [Fact]
    public void Finish_WhenAlreadyFinished_ThrowsInvalidOperationException()
    {
        // Arrange
        var coffeeBag = CreateCoffeeBag();
        var openedDate = new DateOnly(2026, 10, 22);
        var finishedDate = new DateOnly(2026, 10, 25);

        coffeeBag.Open(openedDate);
        coffeeBag.Finish(finishedDate);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(
            () => coffeeBag.Finish(finishedDate.AddDays(1)));
    }
}
