using HomeFinance.Core.Entities;

namespace HomeFinance.Core.Repositories;

public interface IPersonRepository
{
    Task CreateAsync(Person person);
    Task<Person?> GetByNameAsync(string name);
}