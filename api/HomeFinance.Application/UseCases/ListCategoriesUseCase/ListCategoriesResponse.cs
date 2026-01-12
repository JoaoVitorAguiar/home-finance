namespace HomeFinance.Application.UseCases.ListCategoriesUseCase;

public sealed record ListCategoriesResponse(
    int Id,
    string Description,
    string Purpose
);