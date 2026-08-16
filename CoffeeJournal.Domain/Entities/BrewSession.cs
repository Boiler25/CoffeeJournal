namespace CoffeeJournal.Domain.Entities;

public class BrewSession
{
    private BrewSession()
    {
    }

    public BrewSession(
        Guid userId,
        Guid coffeeBagId,
        Guid recipeId,
        DateTime brewedAt,
        Guid? grinderId = null,
        string? grindSize = null,
        int? sweetness = null,
        int? acidity = null,
        int? bitterness = null,
        string? flavorNotes = null,
        string? notes = null,
        string? nextTimeNotes = null)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(
                "User id cannot be empty.",
                nameof(userId));

        if (coffeeBagId == Guid.Empty)
            throw new ArgumentException(
                "Coffee bag id cannot be empty.",
                nameof(coffeeBagId));

        if (recipeId == Guid.Empty)
            throw new ArgumentException(
                "Recipe id cannot be empty.",
                nameof(recipeId));

        if (brewedAt > DateTime.UtcNow)
            throw new ArgumentException(
                "The brewing date cannot be in the future.",
                nameof(brewedAt));

        ValidateRating(sweetness, nameof(sweetness));
        ValidateRating(acidity, nameof(acidity));
        ValidateRating(bitterness, nameof(bitterness));

        Id = Guid.CreateVersion7();

        UserId = userId;

        CoffeeBagId = coffeeBagId;

        RecipeId = recipeId;

        GrinderId = grinderId;

        BrewedAt = brewedAt;

        GrindSize = grindSize?.Trim();

        Sweetness = sweetness;

        Acidity = acidity;

        Bitterness = bitterness;

        FlavorNotes = flavorNotes?.Trim();

        Notes = notes?.Trim();

        NextTimeNotes = nextTimeNotes?.Trim();
    }

    private static void ValidateRating(
        int? value,
        string parameterName)
    {
        if (value is < 1 or > 5)
            throw new ArgumentException(
                "Rating must be between 1 and 5.",
                parameterName);
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Guid CoffeeBagId { get; private set; }

    public Guid RecipeId { get; private set; }

    public Guid? GrinderId { get; private set; }

    public DateTime BrewedAt { get; private set; }

    public string? GrindSize { get; private set; }

    public int? Sweetness { get; private set; }

    public int? Acidity { get; private set; }

    public int? Bitterness { get; private set; }

    public string? FlavorNotes { get; private set; }

    public string? Notes { get; private set; }

    public string? NextTimeNotes { get; private set; }

    public User User { get; private set; } = null!;

    public CoffeeBag CoffeeBag { get; private set; } = null!;

    public Recipe Recipe { get; private set; } = null!;

    public Grinder? Grinder { get; private set; }
}