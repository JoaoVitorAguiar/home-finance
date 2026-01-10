using HomeFinance.Core.Repositories;
using HomeFinance.Infra.Context;
using HomeFinance.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }
}