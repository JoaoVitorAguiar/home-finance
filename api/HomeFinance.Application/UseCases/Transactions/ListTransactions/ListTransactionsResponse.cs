namespace HomeFinance.Application.UseCases.Transactions.ListTransactions;

public record PersonSummary
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public record CategorySummary
{
    public int Id { get; set; }
    public string Description { get; set; }
}


public record ListTransactionsResponse(
    int Id,
    string Description,
    decimal Amount,
    string Type,
    PersonSummary Person,
    CategorySummary Category,
    DateTime CreatedAt
);
