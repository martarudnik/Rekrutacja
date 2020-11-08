using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Zadanie01.Database;
using Zadanie01.Interfaces;
using Zadanie01.Models;

namespace Zadanie01.Services
{
    public class PismoService : IPismoService
    {
        private readonly TestContext _testContext;

        public PismoService( TestContext testContext)
        {
            this._testContext = testContext;
        }
        public List<PismoModel> PobierzPismaWgStandardow()
        {
            var pisma = _testContext.Pisma.Where(x => x.Priorytet)
                                     .Where(item => !_testContext.KorespondencjePisma.Any(item2 => item2.IdPismo == item.Id))
                                     .Select(a => new PismoModel
                                     {
                                         Id = a.Id,
                                         Nazwa = a.Nazwa,
                                         Numer = a.Numer,
                                         Priorytet = a.Priorytet
                                     })
                                     .ToList();
            return pisma;
        }
        public List<KorespondencjaPismaModel> PobierzWysylkiWgStandardow()
        {
            var korespondencje = _testContext.KorespondencjePisma
                                 .Include(x => x.Pismo)
                                 .Include(x => x.Korespondencja)
                                 .OrderByDescending(x => x.Korespondencja.DataWysylki)
                                 .Select(x => new KorespondencjaPismaModel
                                 {
                                     DataWysylki = x.Korespondencja.DataWysylki.ToString("MM/dd/yyyy"),
                                     NazwaPisma = x.Pismo.Nazwa,
                                     NumerPisma = x.Pismo.Numer
                                 })
                                 .ToList();
            return korespondencje;
        }

        public List<WysylkiModel> PobierzLiczbeWyslanychPismWgDnia()
        {
            var resultaty = _testContext.KorespondencjePisma
                           .Include(x => x.Korespondencja)
                           .GroupBy(p => p.Korespondencja.DataWysylki)
                           .Select(g => new WysylkiModel
                           {
                               DataWysylki = g.Key.ToString("MM/dd/yyyy"),
                               LiczbaWyslanychPism = g.Count()
                           }).ToList();

            return resultaty;
        }
    }
}