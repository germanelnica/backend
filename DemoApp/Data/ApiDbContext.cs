using Microsoft.EntityFrameworkCore;
using DemoApp.Models;

namespace DemoApp.Data;

public class ApiDbContext : DbContext, IDatabaseContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
    : base(options)
    {
    }

    public DbSet<CarBrand> CarBrand { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
}