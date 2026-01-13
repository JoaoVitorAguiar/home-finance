using HomeFinance.Application.UseCases.Categories.ListCategoriesUseCase;
using HomeFinance.Core.Repositories;

namespace HomeFinance.Application.UseCases.Categories.ListCategoriesUseCase;

public static class ListCategoriesHandler
{
    public static async Task<List<ListCategoriesResponse>> Handle(
        ListCategoriesQuery command,
        ICategoryRepository categoryRepository
    )
    {
        var categories = await categoryRepository.GetAllAsync();

        return categories
            .Select(c => new ListCategoriesResponse(
                c.Id,
                c.Description,
                c.Purpose.ToString()
            ))
            .ToList();
    }
}