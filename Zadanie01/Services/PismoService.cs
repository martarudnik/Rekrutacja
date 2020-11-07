using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PobieranieDanychZBazy.Models;
using System.Collections.Generic;
using System.Linq;
using Zadanie01.Database;

namespace PobieranieDanychZBazy.Services
{
    public class PismoService
    {
        private readonly IConfiguration _configuration;
        public PismoService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }
        public List<PismoModel> PobierzPismaWgStandardow()
        {
            using var context = new TestContext(_configuration.GetConnectionString("Default"));
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
            using var context = new TestContext(_configuration.GetConnectionString("Default"));
            var korespondencje = context.KorespondencjePisma.Include("Pismo")
                                 .Include("Korespondencja")
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
            using var context = new TestContext(_configuration.GetConnectionString("Default"));
            var resultaty = context.KorespondencjePisma
                           .Include(x => x.Pismo)
                           .Include(x => x.Korespondencja)
                           .Select(x => new WysylkiModel()
                           {
                               DataWysylki = x.Korespondencja.DataWysylki.ToString("MM/dd/yyyy"),
                               LiczbaWyslanychPism = x.Korespondencja.KorespondencjePisma.Count
                           })
                           .Distinct()
                           .ToList();

            return resultaty;
        }
    }
}