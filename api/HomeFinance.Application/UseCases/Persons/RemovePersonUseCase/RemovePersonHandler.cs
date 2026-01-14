using HomeFinance.Application.Exceptions;
using HomeFinance.Application.UseCases.Persons.ListPersonsUseCase;
using HomeFinance.Core.Repositories;

namespace HomeFinance.Application.UseCases.Persons.RemovePersonUseCase;

public static class RemovePersonHandler
{
    public static async Task Handle(
        RemovePersonCommand command,
        IPersonRepository personRepository
    )
    {
        var person = await personRepository.GetByIdAsync(command.id);
        if (person is null) throw new NotFoundException($"Person with id {command.id} not found");
        
        await personRepository.RemoveAsync(person);
    }
}