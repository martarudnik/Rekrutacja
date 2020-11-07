using System;
using System.ComponentModel.DataAnnotations;

namespace Zadanie03.Models
{
    public class Zastepstwo
    {
        private DateTime? _dataRozpoczecia;

        public long Id { get; set; }


        public DateTime? DataRozpoczecia
        {
            get
            {
                return _dataRozpoczecia;
            }
            set
            {
                _dataRozpoczecia = value;
            }
        }

        //public DateTime? DataRozpoczecia { get; set; }


        public DateTime? DataZakonczenia { get; set; }
    }
}