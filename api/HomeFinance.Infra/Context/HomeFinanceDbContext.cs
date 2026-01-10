using HomeFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Infra.Context;

public class HomeFinanceDbContext(DbContextOptions<HomeFinanceDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}