using System.Data;
using HomeFinance.Core.Repositories;
using HomeFinance.Infra.Context;
using HomeFinance.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace HomeFinance.Infra.DependencyInjection;

public static class InfraModule
{
    public static IServiceCollection AddInfraModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HomeFinanceDbContext>(opt =>
            opt.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            ));
        
        services.AddScoped<IDbConnection>(sp =>
            new NpgsqlConnection(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        return services;
    }
}