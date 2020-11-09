using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Zadanie02.Database;
using Zadanie02.Interfaces;
using Zadanie02.Models;

namespace Zadanie02.Services
{
    public class PismoService:IPismoService
    {
        private readonly PismoContext _testContext;
        public PismoService(PismoContext testContext)
        {
            this._testContext = testContext;
        }
        public IList<PismoModel> PobierzWszytskiePisma()
        {
            var resultaty = _testContext.Pisma.ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pismo, PismoModel>();
            });
            return config.CreateMapper().Map<List<Pismo>, List<PismoModel>>(resultaty);
        }
        public IList<PismoModel> PobierzPismaWgStandardow()
        {
            var resultaty = _testContext.Pisma.Where(x => !x.CzySkasowany)
                                    .Where(x => x.Priorytet)
                                    .Where(x => x.Rocznik == Const.Const.Rocznik)
                                    .ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pismo, PismoModel>();
            });

            return config.CreateMapper().Map<List<Pismo>, List<PismoModel>>(resultaty);

        }
    }
}