using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie02.Database;
using Zadanie02.Models;

namespace Zadanie02.Services
{
    public class PismoService
    {
        private TestContext testContext;
        public PismoService()
        {
            ZdefiniujContext();
        }
        public IEnumerable<Pismo> PobierzWszytskiePisma()
        {
            return testContext.Pisma;
        }
        public IList<PismoModel> PobierzPismaWgStandardow()
        {
            var resultaty =  testContext.Pisma.Where(x => !x.CzySkasowany)
                                    .Where(x => x.Priorytet)
                                    .Where(x => x.Rocznik == Const.Const.Rocznik)
                                    .ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pismo, PismoModel>();
            });

            return config.CreateMapper().Map<List<Pismo>, List<PismoModel>>(resultaty);

        }
        private void ZdefiniujContext()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            this.testContext = new TestContext(options);
            testContext.Database.EnsureCreated();
        }
    }
}