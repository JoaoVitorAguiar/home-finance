using HomeFinance.Core.Entities;
using HomeFinance.Core.Repositories;
using HomeFinance.Infra.Context;

namespace HomeFinance.Infra.Repositories;

public class TransactionRepository(HomeFinanceDbContext dbContext) : ITransactionRepository
{
    public async Task CreateAsync(Transaction transaction)
    {
        await dbContext.Transactions.AddAsync(transaction);
        await dbContext.SaveChangesAsync();
    }
}