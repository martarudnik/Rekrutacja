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
            Console.WriteLine("Zadanie 1");

            Console.WriteLine("Punkt 1 -> Wszystkie wysyłki:");
            var wysylki = service.PobierzWysylkiWgStandardow();
            ConsoleTable.From<KorespondencjaPismaModel>(wysylki).Write();


            Console.WriteLine("Punkt 2-> Wszystkie pisma priorytetowe, które nie zostały wysłane: {0}", pisma.Count);
            ConsoleTable.From<PismoModel>(pisma).Write();

            Console.WriteLine("Punkt 3 -> Liczba wyslanych pism wg daty");
            var asd =  service.PobierzLiczbeWyslanychPismWgDnia();
            ConsoleTable.From<WysylkiModel>(asd).Write();
            Console.ReadKey();
        }
    }
}