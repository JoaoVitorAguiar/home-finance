namespace HomeFinance.Application.UseCases.Persons.ListPersonsUseCase;

public sealed record ListPersonsResponse(
    int Id,
    string Name,
    int Age
);