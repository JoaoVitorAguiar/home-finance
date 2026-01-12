using HomeFinance.Application.UseCases.Categories.CreateCategoryUseCase;
using HomeFinance.Application.UseCases.ListCategoriesUseCase;
using Wolverine;

namespace HomeFinance.Api.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/categories")
            .WithTags("Categories");

        group.MapPost("/", async (CreateCategoryCommand command, IMessageBus bus) =>
            {
                var categoryId = await bus.InvokeAsync<int>(command);

                return Results.Created("/categories", new { id = categoryId });
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status409Conflict);
        
        group.MapGet("/", async (IMessageBus bus) =>
            {
                var query = new ListCategoriesQuery();
                var persons = await bus.InvokeAsync<List<ListCategoriesResponse>>(query);
                return Results.Ok(persons);
            })
            .Produces<List<ListCategoriesResponse>>(StatusCodes.Status200OK);
    }
}
