using HomeFinance.Core.Entities;

namespace HomeFinance.Core.Repositories;

public interface ICategoryRepository
{
    Task CreateAsync(Category category);
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> GetByDescriptionAsync(string description);
    Task<List<Category>> GetAllAsync();
}