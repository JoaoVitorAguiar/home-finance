using HomeFinance.Application.Exceptions;
using HomeFinance.Core.Entities;
using HomeFinance.Core.Repositories;

namespace HomeFinance.Application.UseCases.Persons.ListPersonsUseCase;

public static class CreatePersListPersonsHandler
{
    public static async Task<List<ListPersonsResponse>> Handle(
        ListPersonsQuery command,
        IPersonRepository personRepository
    )
    {
        var persons = await personRepository.GetAllAsync();
        return persons
            .Select(p => new ListPersonsResponse(p.Id, p.Name, p.Age))
            .ToList();
    }
}