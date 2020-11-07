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
using Microsoft.Extensions.DependencyInjection;
using PobieranieDanychZBazy;
using PobieranieDanychZBazy.Interfaces;
using System;

namespace Zadanie01
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            var pismoService = startup.Provider.GetRequiredService<IPismoService>();

            PobierzWysylkiWgStandardow(pismoService);
            PobierzPismaWgStandardow(pismoService);
            PobierzLiczbeWyslanychPismWgDnia(pismoService);

            Console.ReadKey();
        }

        private static void PobierzWysylkiWgStandardow(IPismoService pismoService)
        { 
            var wysylki = pismoService.PobierzWysylkiWgStandardow();

            Console.WriteLine("Punkt 1 -> Wszystkie wysyłki:");
            ConsoleTable.From(wysylki).Write();
        }
        private static void PobierzPismaWgStandardow(IPismoService pismoService)
        {
            var pisma = pismoService.PobierzPismaWgStandardow();

            Console.WriteLine("Punkt 2-> Wszystkie pisma priorytetowe, które nie zostały wysłane: {0}", pisma.Count);
            ConsoleTable.From(pisma).Write();
        }
        private static void PobierzLiczbeWyslanychPismWgDnia(IPismoService pismoService)
        {
            var liczbeWyslanychPismWgDnia = pismoService.PobierzLiczbeWyslanychPismWgDnia();

            Console.WriteLine("Punkt 3 -> Liczba wyslanych pism wg daty");
            ConsoleTable.From(liczbeWyslanychPismWgDnia).Write();
        }
    }
}