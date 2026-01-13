using System.Data;
using Dapper;
using HomeFinance.Application.Common;

namespace HomeFinance.Application.UseCases.Transactions.ListTransactions;


public static class ListTransactionsHandler
{
    public static async Task<PagedResult<ListTransactionsResponse>> Handle(
        ListTransactionsQuery query,
        IDbConnection connection)
    {
        var page = query.Page <= 0 ? 1 : query.Page;
        var pageSize = query.PageSize <= 0 ? 10 : query.PageSize;
        var offset = (page - 1) * pageSize;

        const string listSql = """
            SELECT 
                t."Id",
                t."Description",
                t."Amount",
                t."Type",
                t."CreatedAt",
                p."Id" AS Id,
                p."Name" AS Name,
                c."Id" AS Id,
                c."Description" AS Description
            FROM "Transactions" t
            INNER JOIN "Persons" p ON p."Id" = t."PersonId"
            INNER JOIN "Categories" c ON c."Id" = t."CategoryId"
            ORDER BY t."CreatedAt" DESC
            LIMIT @PageSize OFFSET @Offset;
        
        """;

        const string countSql = """
            SELECT COUNT(1)
            FROM "Transactions";
        """;

        var items = (await connection.QueryAsync<
            ListTransactionsFlat,
            PersonSummary,
            CategorySummary,
            ListTransactionsResponse>(
            listSql,
            (t, person, category) =>
                new ListTransactionsResponse(
                    t.Id,
                    t.Description,
                    t.Amount,
                    t.Type,
                    person,
                    category,
                    t.CreatedAt
                ),
            new { PageSize = pageSize, Offset = offset },
            splitOn: "Id,Id"
        )).ToList();

        var totalItems = await connection.ExecuteScalarAsync<int>(countSql);

        return new PagedResult<ListTransactionsResponse>
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = items
        };
    }
}


internal record ListTransactionsFlat(
    int Id,
    string Description,
    decimal Amount,
    string Type,
    DateTime CreatedAt
);
