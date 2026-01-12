using HomeFinance.Core.Entities;
using HomeFinance.Core.Repositories;
using HomeFinance.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Infra.Repositories;

public class CategoryRepository(HomeFinanceDbContext dbContext) : ICategoryRepository
{
    public async Task CreateAsync(Category category)
    {
        await dbContext.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public Task<Category?> GetByDescriptionAsync(string description)
    {
        return dbContext.Categories.SingleOrDefaultAsync(c => c.Description == description);
    }
}