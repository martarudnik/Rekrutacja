using Microsoft.EntityFrameworkCore;
using PobieranieDanychZBazy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie01.Database;

namespace PobieranieDanychZBazy.Services
{
    public class PimsoService 
    {
        // Polecenie 2: wszystkie pisma priorytetowe, które nie zostały wysłane    
        public List<PismoModel> PobierzPismaWgStandardow()
        {
           using var context = new TestContext();
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
            using var context = new TestContext();
            var korespondencje = context.KorespondencjePisma.Include("Pismo")
                                 .Include("Korespondencja")
                                 .Select(x => new KorespondencjaPismaModel
                                 {
                                     DataWysylki = x.Korespondencja.DataWysylki,
                                     NazwaPisma = x.Pismo.Nazwa, 
                                     NumerPisma = x.Pismo.Numer 
                                 }).OrderByDescending(x=>x.DataWysylki)
                                 .ToList();
            return korespondencje;
        }

    }
}