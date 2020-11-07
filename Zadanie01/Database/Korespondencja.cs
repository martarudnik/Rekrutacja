using System;
using System.Collections.Generic;

namespace Zadanie01.Database
{
    public class Korespondencja
    {
        public string Id { get; set; }

        public DateTime DataWysylki { get; set; }
        public ICollection<KorespondencjaPisma> KorespondencjePisma { get; set; }
    }
}