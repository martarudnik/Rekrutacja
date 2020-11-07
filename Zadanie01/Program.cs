/* ***************************************************************************************************** */
/*                                                                                                       */
/* 1) Uzupełnij mappingi EF                                                                              */
/* 2) Wyświetl wszystkie wysyłki:                                                                        */
/*    a) sortując po dacie wysyłki malejąco                                                              */
/*    b) wyświetl sformatowaną tabelę zawierającą: numer wiersza, datę wysyłki, nazwę pisma, numer pisma */
/* 3) Wyświetl wszystkie pisma priorytetowe, które nie zostały wysłane                                   */
/* 4) Wyświetl sformatowaną tabelę zawierającą: date wysyłki, ilość wysłanych pism                       */
/*                                                                                                       */
/* ***************************************************************************************************** */
using ConsoleTables;
using PobieranieDanychZBazy.Models;
using PobieranieDanychZBazy.Services;
using System;

namespace Zadanie01
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PimsoService();
            var pisma = service.PobierzPismaWgStandardow();
            Console.WriteLine("Wszystkie pisma priorytetowe, które nie zostały wysłane: {0}", pisma.Count);
            ConsoleTable.From<PismoModel>(pisma).Write();

            var zadanie02 = service.PobierzWysylkiWgStandardow();
            ConsoleTable.From<KorespondencjaPismaModel>(zadanie02).Write();
            Console.ReadKey();
        }
    }
}