using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PobieranieDanychZBazy.Interfaces;
using PobieranieDanychZBazy.Services;
using System;
using System.IO;

namespace PobieranieDanychZBazy
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