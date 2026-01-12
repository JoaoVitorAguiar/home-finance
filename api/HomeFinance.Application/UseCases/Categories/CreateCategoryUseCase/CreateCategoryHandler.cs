using HomeFinance.Application.Exceptions;
using HomeFinance.Core.Entities;
using HomeFinance.Core.Enums;
using HomeFinance.Core.Repositories;

namespace HomeFinance.Application.UseCases.Categories.CreateCategoryUseCase;

public static class CreateCategoryHandler
{
    public static async Task<int> Handle(
        CreateCategoryCommand command,
        ICategoryRepository categoryRepository
    )
    {
        var existingCategory = await categoryRepository.GetByDescriptionAsync(command.Description);

        if (existingCategory is not null)
            throw new AlreadyExistsException($"Category '{command.Description}' already exists.");

        if (!Enum.TryParse<CategoryPurpose>(command.Purpose, true, out var purpose))
            throw new ConflictException("Invalid category purpose. Allowed values: Expense, Income, Both.");

        var category = new Category(
            command.Description,
            purpose
        );

        await categoryRepository.CreateAsync(category);

        return category.Id;
    }
}