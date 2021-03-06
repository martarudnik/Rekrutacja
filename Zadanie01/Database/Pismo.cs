﻿using System.Collections.Generic;

namespace Zadanie01.Database
{
    public class Pismo
    {
        public string Id { get; set; }

        public string Nazwa { get; set; }

        public string Numer { get; set; }

        public bool Priorytet { get; set; }

        public ICollection<KorespondencjaPisma> KorespondencjePisma { get; set; }
    }
}