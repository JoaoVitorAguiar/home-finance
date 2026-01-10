using HomeFinance.Core.Entities;
using HomeFinance.Core.Repositories;
using HomeFinance.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Infra.Repositories;

public class PersonRepository(HomeFinanceDbContext dbContext) : IPersonRepository
{
    public async Task CreateAsync(Person person)
    {
        await dbContext.Persons.AddAsync(person);
        await dbContext.SaveChangesAsync();
    }

    public Task<Person?> GetByNameAsync(string name)
    {
        return dbContext.Persons.SingleOrDefaultAsync(p => p.Name == name);
    }

    public Task<List<Person>> GetAllAsync()
    {
        return dbContext.Persons.ToListAsync();
    }
}