namespace HomeFinance.Application.UseCases.Transactions.ListTransactions;

public sealed record ListTransactionsQuery(
    int Page = 1,
    int PageSize = 10
);