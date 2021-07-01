using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApplication.Persistenses.Context
{
    public class DataAppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=postgres; password=postgres; database=ecommerce;");
        return new AppDbContext(optionsBuilder.Options);
    }
        
    }
}