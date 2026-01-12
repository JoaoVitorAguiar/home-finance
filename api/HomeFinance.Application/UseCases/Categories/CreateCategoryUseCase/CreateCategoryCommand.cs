namespace HomeFinance.Application.UseCases.Categories.CreateCategoryUseCase;

/// <summary>
/// Command used to create a new category in the system.
/// </summary>
public sealed record CreateCategoryCommand
{
    /// <summary>
    /// Description of the category.
    /// </summary>
    /// <example>Food</example>
    public string Description { get; init; } = default!;

    /// <summary>
    /// Purpose of the category: Expense, Income or Both.
    /// </summary>
    /// <example>Expense</example>
    public string Purpose { get; init; } = default!;
}