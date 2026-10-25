
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Tests.Domain;

public class BrewSessionTests
{
    [Fact]
    public void Constructor_WithValidData_CreatesBrewSession()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var coffeeBagId = Guid.NewGuid();
        var recipeId = Guid.NewGuid();
        var brewedAt = DateTime.UtcNow.AddMinutes(-1);

        // Act
        var session = new BrewSession(
            userId,
            coffeeBagId,
            recipeId,
            brewedAt,
            sweetness: 4,
            acidity: 3,
            bitterness: 2);

        // Assert
        Assert.NotEqual(Guid.Empty, session.Id);
        Assert.Equal(userId, session.UserId);
        Assert.Equal(coffeeBagId, session.CoffeeBagId);
        Assert.Equal(recipeId, session.RecipeId);
        Assert.Equal(brewedAt, session.BrewedAt);
        Assert.Equal(4, session.Sweetness);
        Assert.Equal(3, session.Acidity);
        Assert.Equal(2, session.Bitterness);
    }

    [Fact]
    public void Constructor_WithEmptyUserId_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(userId: Guid.Empty));
    }

    [Fact]
    public void Constructor_WithEmptyCoffeeBagId_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(coffeeBagId: Guid.Empty));
    }

    [Fact]
    public void Constructor_WithEmptyRecipeId_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(recipeId: Guid.Empty));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void Constructor_WithInvalidSweetness_ThrowsArgumentException(
        int sweetness)
    {
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(sweetness: sweetness));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void Constructor_WithInvalidAcidity_ThrowsArgumentException(
        int acidity)
    {
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(acidity: acidity));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void Constructor_WithInvalidBitterness_ThrowsArgumentException(
        int bitterness)
    {
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(bitterness: bitterness));
    }

    [Fact]
    public void Constructor_WithFutureBrewedAt_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            CreateBrewSession(
                brewedAt: DateTime.UtcNow.AddMinutes(5)));
    }

    [Fact]
    public void Constructor_WithTextFields_TrimsWhitespace()
    {
        // Act
        var session = CreateBrewSession();

        // Assert
        Assert.Equal("medium", session.GrindSize);
        Assert.Equal("chocolate", session.FlavorNotes);
        Assert.Equal("tasting notes", session.Notes);
        Assert.Equal("finer grind", session.NextTimeNotes);
    }

    private static BrewSession CreateBrewSession(
        Guid? userId = null,
        Guid? coffeeBagId = null,
        Guid? recipeId = null,
        DateTime? brewedAt = null,
        int? sweetness = null,
        int? acidity = null,
        int? bitterness = null)
    {
        return new BrewSession(
            userId ?? Guid.NewGuid(),
            coffeeBagId ?? Guid.NewGuid(),
            recipeId ?? Guid.NewGuid(),
            brewedAt ?? DateTime.UtcNow.AddMinutes(-1),
            sweetness: sweetness,
            acidity: acidity,
            bitterness: bitterness,
            grindSize: " medium ",
            flavorNotes: " chocolate ",
            notes: " tasting notes ",
            nextTimeNotes: " finer grind ");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void Constructor_WithBoundaryRatingValues_CreatesBrewSession(
    int rating)
    {
        // Act
        var session = CreateBrewSession(
            sweetness: rating,
            acidity: rating,
            bitterness: rating);

        // Assert
        Assert.Equal(rating, session.Sweetness);
        Assert.Equal(rating, session.Acidity);
        Assert.Equal(rating, session.Bitterness);
    }

    [Fact]
    public void Constructor_WithOptionalFieldsMissing_SetsThemToNull()
    {
        // Act
        var session = new BrewSession(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.UtcNow.AddMinutes(-1));

        // Assert
        Assert.Null(session.GrinderId);
        Assert.Null(session.GrindSize);
        Assert.Null(session.Sweetness);
        Assert.Null(session.Acidity);
        Assert.Null(session.Bitterness);
        Assert.Null(session.FlavorNotes);
        Assert.Null(session.Notes);
        Assert.Null(session.NextTimeNotes);
    }
}
