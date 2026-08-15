namespace CoffeeJournal.Domain.Entities;

public class User
{
    private User()
    {
    }

    public User(
        string username,
        string email)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException(
                "Username cannot be empty.",
                nameof(username));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException(
                "Email cannot be empty.",
                nameof(email));

        Id = Guid.CreateVersion7();

        Username = username.Trim();

        Email = email.Trim();
    }

    public Guid Id { get; private set; }

    public string Username { get; private set; }

    public string Email { get; private set; }

    public ICollection<CoffeeBag> CoffeeBags { get; private set; }
        = new List<CoffeeBag>();

    public ICollection<Recipe> Recipes { get; private set; }
        = new List<Recipe>();

    public ICollection<Grinder> Grinders { get; private set; }
        = new List<Grinder>();

    public ICollection<BrewSession> BrewSessions { get; private set; }
        = new List<BrewSession>();
}