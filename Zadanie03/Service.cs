using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie03
{
    public static class Service
    {
        public static List<Zastepstwo> PobierzZastepstwaNaPodstawieDaty(DateTime date, List<Zastepstwo> zastepstwa)
        {
            var resultaty = zastepstwa.Where(e => (e.DataRozpoczecia.HasValue && e.DataRozpoczecia <= date) || !e.DataRozpoczecia.HasValue)
                                      .Where(e => (e.DataZakonczenia.HasValue && e.DataZakonczenia >= date) || !e.DataZakonczenia.HasValue)
                                      .ToList();
            return resultaty;
        }
    }
}