using HomeFinance.Application.Exceptions;
using HomeFinance.Core.Entities;
using HomeFinance.Core.Enums;
using HomeFinance.Core.Repositories;

namespace HomeFinance.Application.UseCases.Transactions.CreateTransactionUseCase;


public static class CreateTransactionHandler
{
    public static async Task<int> Handle(
        CreateTransactionCommand command,
        IPersonRepository personRepository,
        ICategoryRepository categoryRepository,
        ITransactionRepository transactionRepository
    )
    {
        if (!Enum.TryParse<TransactionType>(command.Type, true, out var type))
            throw new ConflictException(
                "Invalid transaction type. Allowed values are: Expense or Income.");

        var person = await personRepository.GetByIdAsync(command.PersonId)
                     ?? throw new NotFoundException(
                         $"Person with id '{command.PersonId}' was not found.");

        var category = await categoryRepository.GetByIdAsync(command.CategoryId)
                       ?? throw new NotFoundException(
                           $"Category with id '{command.CategoryId}' was not found.");

        var transaction = new Transaction(
            command.Description,
            command.Amount,
            type,
            person,
            category
        );

        await transactionRepository.CreateAsync(transaction);

        return transaction.Id;
    }
}
