namespace HomeFinance.Application.UseCases.Reports.GetTotalsByCategoryUseCase;

public record CategoryTotalsItem(
    int CategoryId,
    string CategoryDescription,
    decimal TotalIncome,
    decimal TotalExpense
);

public record TotalsByCategoryResponse(
    List<CategoryTotalsItem> Items,
    decimal TotalIncome,
    decimal TotalExpense,
    decimal Balance
);
