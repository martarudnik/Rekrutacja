using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Zadanie01.Database;
using Zadanie01.Interfaces;
using Zadanie01.Services;

namespace PobieranieDanychZBazy
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionstring = configuration.GetConnectionString("Default");

            var collection = new ServiceCollection()
                            .AddSingleton<IPismoService, PismoService>()
                            .AddDbContext<TestContext>(options => options.UseSqlServer(connectionstring));

            Provider = collection.BuildServiceProvider();
        }

        public IServiceProvider Provider { get; }
    }
}