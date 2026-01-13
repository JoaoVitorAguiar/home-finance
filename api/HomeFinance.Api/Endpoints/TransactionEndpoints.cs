using HomeFinance.Application.UseCases.Transactions.CreateTransactionUseCase;
using Wolverine;

namespace HomeFinance.Api.Endpoints;

public static class TransactionEndpoints
{
    public static void MapTransactionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/transactions")
            .WithTags("Transactions");

        group.MapPost("/", async (CreateTransactionCommand command, IMessageBus bus) =>
            {
                var transactionId = await bus.InvokeAsync<int>(command);

                return Results.Created($"/transactions", new { id = transactionId });
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status409Conflict);
    }
}