using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Zadanie02.Database;
using Zadanie02.Interfaces;
using Zadanie02.Services;

namespace Zadanie02
{
    public class Startup
    {
        public Startup()
        {
            var collection = new ServiceCollection()
                                .AddSingleton<IPismoService, PismoService>();

            collection.AddDbContextPool<PismoContext>(
                            options => options.UseSqlServer(ConfigSettings.ConnectionString,
                            b => b.MigrationsAssembly(typeof(PismoContext).Assembly.GetName().Name)));

            Provider = collection.BuildServiceProvider();
        }

        public IServiceProvider Provider { get; }
    }
}