using HomeFinance.Application.UseCases.Reports.GetTotalsByCategoryUseCase;
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
        }).Produces<List<TotalsByPersonResponse>>(StatusCodes.Status200OK);
        
        group.MapGet("/by-category", async (IMessageBus bus) =>
        {
            var query = new GetTotalsByCategoryQuery();
            var result = await bus.InvokeAsync<TotalsByCategoryResponse>(query);

            return Results.Ok(result);
        }).Produces<List<TotalsByCategoryResponse>>(StatusCodes.Status200OK);
    }
}
