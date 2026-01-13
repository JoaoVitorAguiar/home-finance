using System.Data;
using Dapper;

namespace HomeFinance.Application.UseCases.Reports.GetTotalsByPersonUseCase;

public static class GetTotalsByPersonHandler
{
    public static async Task<TotalsByPersonResponse> Handle(
        GetTotalsByPersonQuery query,
        IDbConnection connection)
    {
        const string sql = """
            SELECT 
                p."Id"   AS PersonId,
                p."Name" AS PersonName,
                
                COALESCE(SUM(CASE 
                    WHEN t."Type" = 'Income' THEN t."Amount" 
                    ELSE 0 
                END), 0) AS TotalIncome,

                COALESCE(SUM(CASE 
                    WHEN t."Type" = 'Expense' THEN t."Amount" 
                    ELSE 0 
                END), 0) AS TotalExpense
            
            FROM "Persons" p
            LEFT JOIN "Transactions" t ON t."PersonId" = p."Id"
            GROUP BY p."Id", p."Name"
            ORDER BY p."Id";
        """;

        var items = (await connection.QueryAsync<PersonTotalsItem>(sql)).ToList();

        var totalIncome = items.Sum(x => x.TotalIncome);
        var totalExpense = items.Sum(x => x.TotalExpense);

        return new TotalsByPersonResponse(
            items,
            totalIncome,
            totalExpense,
            totalIncome - totalExpense
        );

    }
}