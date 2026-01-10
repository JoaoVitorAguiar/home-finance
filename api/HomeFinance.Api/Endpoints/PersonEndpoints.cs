using HomeFinance.Application.UseCases.Persons.CreatePersonUseCase;
using Wolverine;

namespace HomeFinance.Api.Endpoints;

public static class PersonEndpoints
{
    public static void MapPersonEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/persons")
            .WithTags("Persons");

        // POST /persons
        group.MapPost("/", async (CreatePersonCommand command, IMessageBus bus) =>
        {
            var personId = await bus.InvokeAsync<int>(command);
            return Results.Created($"/persons/{personId}", new { id = personId });
        });
    }
}
