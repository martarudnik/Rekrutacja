using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PobieranieDanychZBazy.Interfaces;
using PobieranieDanychZBazy.Models;
using System.Collections.Generic;
using System.Linq;
using Zadanie01.Database;

namespace PobieranieDanychZBazy.Services
{
    public class PismoService : IPismoService
    {
        const string  ConnectiongStringName = "Default";

        private readonly IConfiguration _configuration;

        public PismoService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public List<PismoModel> PobierzPismaWgStandardow()
        {
            using var context = new TestContext(_configuration.GetConnectionString(ConnectiongStringName));
            var pisma = context.Pisma.Where(x => x.Priorytet)
                                     .Where(item => !context.KorespondencjePisma.Any(item2 => item2.IdPismo == item.Id))
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
            using var context = new TestContext(_configuration.GetConnectionString(ConnectiongStringName));
            var korespondencje = context.KorespondencjePisma
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
            using var context = new TestContext(_configuration.GetConnectionString(ConnectiongStringName));

            var resultaty = context.KorespondencjePisma
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