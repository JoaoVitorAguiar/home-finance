using HomeFinance.Core.Enums;

namespace HomeFinance.Core.Entities;

public class Category : BaseEntity
{
    public string Description { get; private set; }
    public CategoryPurpose Purpose { get; private set; }
    public Category(string description, CategoryPurpose purpose)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        Description = description.Trim();
        Purpose = purpose;
    }
    public bool CanBeUsedForExpense()
        => Purpose is CategoryPurpose.Expense or CategoryPurpose.Both;
    public bool CanBeUsedForIncome()
        => Purpose is CategoryPurpose.Income or CategoryPurpose.Both;

}
