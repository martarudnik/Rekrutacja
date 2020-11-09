using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Zadanie02.Database
{
    public class PismoContextFactory : IDesignTimeDbContextFactory<PismoContext>
    {
        public PismoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PismoContext>();

            optionsBuilder.UseSqlServer(ConfigSettings.ConnectionString,
                b => b.MigrationsAssembly(typeof(PismoContext).Assembly.GetName().Name));

            return new PismoContext(optionsBuilder.Options);
        }
    }
}