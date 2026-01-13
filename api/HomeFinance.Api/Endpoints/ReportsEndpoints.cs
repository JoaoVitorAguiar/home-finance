using HomeFinance.Application.UseCases.Reports.GetTotalsByPersonUseCase;
using Wolverine;

namespace HomeFinance.Api.Endpoints;

public static class ReportsEndpoints
{
    public static void MapReportsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/reports")
            .WithTags("Reports");

        group.MapGet("/by-person", async (IMessageBus bus) =>
        {
            var query = new GetTotalsByPersonQuery();
            var result = await bus.InvokeAsync<TotalsByPersonResponse>(query);

            return Results.Ok(result);
        });

    }
}
