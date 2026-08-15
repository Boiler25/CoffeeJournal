namespace CoffeeJournal.Domain.Entities;

public class Roaster
{
    private Roaster()
    {
    }

    public Roaster(
        string name,
        string? country = null,
        string? website = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Roaster name cannot be empty.",
                nameof(name));

        Id = Guid.CreateVersion7();
        Name = name.Trim();
        Country = country?.Trim();
        Website = website?.Trim();
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string? Country { get; private set; }

    public string? Website { get; private set; }

    public ICollection<CoffeeBean> CoffeeBeans { get; private set; }
        = new List<CoffeeBean>();
}