using HomeFinance.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Infra.Context;

public sealed class HomeFinanceDbContext(DbContextOptions<HomeFinanceDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}