using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie02.Database;

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
        public IList<Pismo> PobierzPismaWgStandardow()
        {
            return testContext.Pisma.Where(x => !x.CzySkasowany)
                                    .Where(x => x.Priorytet)
                                    .Where(x => x.Rocznik == Const.Const.Rocznik)
                                    .ToList();
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