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

    public bool IsCompatibleWith(TransactionType type)
    {
        if (Purpose == CategoryPurpose.Both) return true;
        switch (type)
        {
            case TransactionType.Expense when Purpose == CategoryPurpose.Expense:
            case TransactionType.Income when Purpose == CategoryPurpose.Income:
                return true;
            default:
                return false;
        }
    }

}
