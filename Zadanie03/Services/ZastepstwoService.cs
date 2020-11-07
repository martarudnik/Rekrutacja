using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie03.Models;

namespace Zadanie03.Service
{
    public static class ZastepstwoService
    {
        public static List<Zastepstwo> PobierzZastepstwaNaWgDaty(DateTime date, List<Zastepstwo> zastepstwa)
        {
            var resultaty = zastepstwa.Where(e => (e.DataRozpoczecia.HasValue && e.DataRozpoczecia <= date) || !e.DataRozpoczecia.HasValue)
                                      .Where(e => (e.DataZakonczenia.HasValue && e.DataZakonczenia >= date) || !e.DataZakonczenia.HasValue)
                                      .ToList();
            return resultaty;
        }
    }
}