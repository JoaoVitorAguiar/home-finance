using HomeFinance.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinance.Api.Middlewares;

public sealed class DomainExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not DomainException domainException)
            return false; 

        var problem = domainException switch
        {
            UnderageIncomeNotAllowedException ex => CreateProblem(
                StatusCodes.Status422UnprocessableEntity,
                "Business rule violation",
                ex.Message,
                context),

            IncompatibleCategoryException ex => CreateProblem(
                StatusCodes.Status422UnprocessableEntity,
                "Business rule violation",
                ex.Message,
                context)
        };

        context.Response.StatusCode = problem.Status!.Value;
        await context.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }

    private static ProblemDetails CreateProblem(
        int status,
        string title,
        string detail,
        HttpContext context)
    {
        return new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Status = status,
            Instance = context.Request.Path
        };
    }
}