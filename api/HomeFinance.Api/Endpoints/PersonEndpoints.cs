using HomeFinance.Application.UseCases.Persons.CreatePersonUseCase;
using HomeFinance.Application.UseCases.Persons.ListPersonsUseCase;
using HomeFinance.Application.UseCases.Persons.RemovePersonUseCase;
using HomeFinance.Core.Entities;
using Wolverine;

namespace HomeFinance.Api.Endpoints;

public static class PersonEndpoints
{
    public static void MapPersonEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/persons")
            .WithTags("Persons");

        group.MapPost("/", async (CreatePersonCommand command, IMessageBus bus) =>
        {
            var personId = await bus.InvokeAsync<int>(command);
            return Results.Created("/persons", new { id = personId });
        });

        group.MapGet("/", async (IMessageBus bus) =>
            {
                var query = new ListPersonsQuery();
                var persons = await bus.InvokeAsync<List<ListPersonsResponse>>(query);
                return Results.Ok(persons);
            }).Produces<List<ListPersonsResponse>>(StatusCodes.Status200OK);

        group.MapDelete("/{id:int}", async (int id, IMessageBus bus) =>
        {
            var command = new RemovePersonCommand(id);
            await bus.InvokeAsync(command);
            
            return Results.NoContent();
        });

    }
}
