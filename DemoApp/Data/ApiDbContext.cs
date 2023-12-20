using Microsoft.EntityFrameworkCore;
using DemoApp.Models;

namespace DemoApp.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
    : base(options)
    {

    }

    public DbSet<CarBrand> CarBrand { get; set; }
}