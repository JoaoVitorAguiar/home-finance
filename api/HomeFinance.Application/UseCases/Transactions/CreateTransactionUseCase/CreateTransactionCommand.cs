using System.ComponentModel.DataAnnotations;

namespace HomeFinance.Application.UseCases.Transactions.CreateTransactionUseCase;

/// <summary>
/// Command used to create a new financial transaction.
/// </summary>
public sealed record CreateTransactionCommand
{
    /// <summary>
    /// Description of the transaction.
    /// </summary>
    /// <example>Lunch at restaurant</example>
    public string Description { get; init; }

    /// <summary>
    /// Transaction amount. Must be greater than zero.
    /// </summary>
    /// <example>45.90</example>
    public decimal Amount { get; init; }

    /// <summary>
    /// Transaction type: Expense or Income.
    /// </summary>
    /// <example>Expense</example>
    public string Type { get; init; }

    /// <summary>
    /// Person identifier.
    /// </summary>
    /// <example>1</example>
    public int PersonId { get; init; }

    /// <summary>
    /// Category identifier.
    /// </summary>
    /// <example>1</example>
    public int CategoryId { get; init; }
}