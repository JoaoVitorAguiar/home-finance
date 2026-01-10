using FluentValidation;

namespace HomeFinance.Application.UseCases.Persons.CreatePersonUseCase;

public sealed class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Name cannot be empty or whitespace.")
            .MinimumLength(3).WithMessage("Name must have at least 3 characters.")
            .MaximumLength(120).WithMessage("Name must have at most 120 characters.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Birth date is required.")
            .LessThan(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Birth date must be in the past.");
    }
}
