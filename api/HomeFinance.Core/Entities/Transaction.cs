using HomeFinance.Core.Enums;
using HomeFinance.Core.Exceptions;

namespace HomeFinance.Core.Entities;

public class Transaction : BaseEntity
{
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }

    public int PersonId { get; private set; }
    public Person Person { get; private set; }

    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    
    protected Transaction() { } 
    public Transaction(
        string description,
        decimal amount,
        TransactionType type,
        Person person,
        Category category)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.", nameof(description));

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        ValidateMinorRule(type, person);
        ValidateCategoryCompatibility(type, category);

        Description = description.Trim();
        Amount = amount;
        Type = type;
        PersonId = person.Id;
        Person = person;
        CategoryId = category.Id;
        Category = category;
    }
    
    private static void ValidateMinorRule(TransactionType type, Person person)
    {
        if (person.IsUnderage() && type == TransactionType.Income)
            throw new UnderageIncomeNotAllowedException();
    }

    private static void ValidateCategoryCompatibility(TransactionType type, Category category)
    {
        if (!category.IsCompatibleWith(type))
            throw new IncompatibleCategoryException();
    }
}