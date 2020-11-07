using System;
using System.ComponentModel.DataAnnotations;

namespace Zadanie03.Models
{
    public class Zastepstwo
    {
        public long Id { get; set; }

        public DateTime? DataRozpoczecia { get; set; }

        public DateTime? DataZakonczenia { get; set; }
    }
}