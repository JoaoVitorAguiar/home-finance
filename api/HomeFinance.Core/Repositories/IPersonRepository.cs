using HomeFinance.Core.Entities;

namespace HomeFinance.Core.Repositories;

public interface IPersonRepository
{
    Task CreateAsync(Person person);
    Task<Person?> GetByIdAsync(int id);
    Task<Person?> GetByNameAsync(string name);
    Task<List<Person>> GetAllAsync();
    Task RemoveAsync(Person person);
}