using FluentValidation;

namespace HomeFinance.Application.UseCases.Categories.CreateCategoryUseCase;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Must(description => !string.IsNullOrWhiteSpace(description))
            .WithMessage("Description cannot be empty or whitespace.")
            .MinimumLength(3).WithMessage("Description must have at least 3 characters.")
            .MaximumLength(120).WithMessage("Description must have at most 120 characters.");

        RuleFor(x => x.Purpose)
            .NotEmpty().WithMessage("Purpose is required.")
            .Must(purpose =>
                purpose.Equals("expense", StringComparison.OrdinalIgnoreCase) ||
                purpose.Equals("income", StringComparison.OrdinalIgnoreCase) ||
                purpose.Equals("both", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Purpose must be: Expense, Income or Both.");
    }
}