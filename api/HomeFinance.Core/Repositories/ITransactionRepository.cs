using HomeFinance.Core.Entities;

namespace HomeFinance.Core.Repositories;

public interface ITransactionRepository
{
    Task CreateAsync(Transaction transaction);
}