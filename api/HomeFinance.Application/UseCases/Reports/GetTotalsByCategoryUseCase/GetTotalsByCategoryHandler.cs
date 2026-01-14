using System.Data;
using Dapper;

namespace HomeFinance.Application.UseCases.Reports.GetTotalsByCategoryUseCase;

public static class GetTotalsByCategoryHandler
{
    public static async Task<TotalsByCategoryResponse> Handle(
        GetTotalsByCategoryQuery query,
        IDbConnection connection)
    {
        const string sql = """
            SELECT 
            c."Id" AS CategoryId,
            c."Description" AS CategoryDescription,
            
            COALESCE(SUM(CASE 
                WHEN t."Type" = 'Income' THEN t."Amount" 
                ELSE 0 
            END), 0) AS TotalIncome,

            COALESCE(SUM(CASE 
                WHEN t."Type" = 'Expense' THEN t."Amount" 
                ELSE 0 
            END), 0) AS TotalExpense
                                
            FROM "Categories" c
            LEFT JOIN "Transactions" t ON t."CategoryId" = c."Id"
            GROUP BY c."Id", c."Description"
            ORDER BY c."Id";
        """;

        var items = (await connection.QueryAsync<CategoryTotalsItem>(sql)).ToList();

        var totalIncome = items.Sum(x => x.TotalIncome);
        var totalExpense = items.Sum(x => x.TotalExpense);

        return new TotalsByCategoryResponse(
            items,
            totalIncome,
            totalExpense,
            totalIncome - totalExpense
        );
    }
}