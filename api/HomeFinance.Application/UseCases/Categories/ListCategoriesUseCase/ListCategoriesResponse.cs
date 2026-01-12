namespace HomeFinance.Application.UseCases.Categories.ListCategoriesUseCase;

public sealed record ListCategoriesResponse(
    int Id,
    string Description,
    string Purpose
);