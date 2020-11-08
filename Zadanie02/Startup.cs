using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Zadanie02.Interfaces;
using Zadanie02.Services;

namespace Zadanie02
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

            var collection = new ServiceCollection()
                            .AddSingleton<IConfiguration>(builder)
                            .AddSingleton<IPismoService, PismoService>();

            Provider = collection.BuildServiceProvider();
        }

        public IServiceProvider Provider { get; }
        public IConfiguration Configuration { get; }
    }
}