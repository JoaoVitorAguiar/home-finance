namespace HomeFinance.Core.Entities;

public class Person : BaseEntity
{
    public string Name { get; private set; } 
    public DateOnly BirthDate { get; private set; }
    public Person(string name, DateOnly birthDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (birthDate > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("Birth date cannot be in the future.", nameof(birthDate));
        
        
        Name = name.Trim();
        BirthDate = birthDate;
    }
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - BirthDate.Year;

            if (BirthDate > today.AddYears(-age))
                age--;

            return age;
        }
    }
    public bool IsUnderage() => Age < 18;
}