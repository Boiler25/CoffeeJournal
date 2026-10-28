using CoffeeJournal.Application.Abstractions;
using CoffeeJournal.Domain.Entities;

namespace CoffeeJournal.Application.UseCases.BrewSessions;

public sealed class CreateBrewSessionHandler
{
    private readonly IBrewSessionRepository _repository;

    public CreateBrewSessionHandler(IBrewSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(
        CreateBrewSessionCommand command,
        CancellationToken cancellationToken = default)
    {
        var session = new BrewSession(
            userId: command.UserId,
            coffeeBagId: command.CoffeeBagId,
            recipeId: command.RecipeId,
            brewedAt: command.BrewedAt,
            grinderId: command.GrinderId,
            grindSize: command.GrindSize,
            sweetness: command.Sweetness,
            acidity: command.Acidity,
            bitterness: command.Bitterness,
            flavorNotes: command.FlavorNotes,
            notes: command.Notes,
            nextTimeNotes: command.NextTimeNotes);

        await _repository.AddAsync(session, cancellationToken);

        return session.Id;
    }
}