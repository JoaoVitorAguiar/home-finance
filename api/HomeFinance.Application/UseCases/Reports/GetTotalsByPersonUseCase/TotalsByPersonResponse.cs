namespace HomeFinance.Application.UseCases.Reports.GetTotalsByPersonUseCase;

public record PersonTotalsItem
{
    public int PersonId { get; set; }
    public string PersonName { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }

    public decimal Balance => TotalIncome - TotalExpense;
}

public record TotalsByPersonResponse(
    IReadOnlyList<PersonTotalsItem> Items,
    decimal TotalIncome,
    decimal TotalExpense,
    decimal Balance
);