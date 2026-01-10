using HomeFinance.Application.Exceptions;
using HomeFinance.Core.Entities;
using HomeFinance.Core.Repositories;

namespace HomeFinance.Application.UseCases.Persons.CreatePersonUseCase;

public static class CreatePersonHandler
{
    public static async Task<int> Handle(
        CreatePersonCommand command,
        IPersonRepository personRepository
    )
    {
        var person = await personRepository.GetByNameAsync(command.Name);

        if (person is not null)
            throw new AlreadyExistsException($"Person with name '{command.Name}' already exists");


        var newPerson = new Person(
            command.Name,
            command.BirthDate
        );

        await personRepository.CreateAsync(newPerson);

        return newPerson.Id;
    }
}