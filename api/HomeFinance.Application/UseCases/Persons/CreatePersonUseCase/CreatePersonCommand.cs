namespace HomeFinance.Application.UseCases.Persons.CreatePersonUseCase;

/// <summary>
/// Command used to create a new person in the system.
/// </summary>
public sealed record CreatePersonCommand
{
    /// <summary>
    /// Full name of the person.
    /// </summary>
    /// <example>João da Silva</example>
    public string Name { get; init; } = default!;

    /// <summary>
    /// Date of birth of the person.
    /// </summary>
    /// <example>2000-01-01</example>
    public DateOnly BirthDate { get; init; }
}