/* ***************************************************************************************************** */
/*                                                                                                       */
/* 1) Napisz logikę, która dla danej daty wypisze wszystkie zastępstwa                                   */
/* 2) Utwórz test jednostkowy (xunit), dla tej logiki                                                    */
/*                                                                                                       */
/* ***************************************************************************************************** */
using ConsoleTables;
using System;
using System.Collections.Generic;
using Zadanie03.Models;

namespace Zadanie03
{
    class Program
    {
        static void Main(string[] args)
        {
            var dane = PrzygotujDane();
            var zastepstwa = Service.ZastepstwoService.PobierzZastepstwaWgDaty(dane.Item1, dane.Item2);
            Console.WriteLine("Zadanie 3");
            Console.WriteLine($"Wszystkie zastępstwa w dniu {dane.Item1} ");
            ConsoleTable.From(zastepstwa).Write();
            Console.ReadKey();
        }
        private static Tuple<DateTime, List<Zastepstwo>> PrzygotujDane()
        {
            DateTime data = new DateTime(2020, 5, 2);

            var zastepstwa = new List<Zastepstwo>
            {
                new Zastepstwo {
                                Id = 1,
                                DataRozpoczecia = null,
                                DataZakonczenia = null
                               },
                new Zastepstwo {
                                Id = 2,
                                DataRozpoczecia = new DateTime(2020, 1, 1),
                                DataZakonczenia = null},
                new Zastepstwo {
                                Id = 3,
                                DataRozpoczecia = null,
                                DataZakonczenia = new DateTime(2020, 12, 31)},
                new Zastepstwo {
                                Id = 4,
                                DataRozpoczecia = new DateTime(2020, 5, 8),
                                DataZakonczenia = new DateTime(2020, 5, 14)}
            };

            var dane = Tuple.Create(data, zastepstwa);
            return dane;
        }
    }
}