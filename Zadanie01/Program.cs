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
using Microsoft.Extensions.Configuration;
using PobieranieDanychZBazy.Models;
using PobieranieDanychZBazy.Services;
using System;
using System.IO;

namespace Zadanie01
{
    public class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            UstawKonfiguracje();

            PismoService pismoService = new PismoService(_configuration);

            PobierzWysylkiWgStandardow(pismoService);
            PobierzPismaWgStandardow(pismoService);
            PobierzLiczbeWyslanychPismWgDnia(pismoService);

            Console.ReadKey();
        }

        static void UstawKonfiguracje()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }
        private static void PobierzWysylkiWgStandardow(PismoService pismoService)
        { 
            var wysylki = pismoService.PobierzWysylkiWgStandardow();

            Console.WriteLine("Punkt 1 -> Wszystkie wysyłki:");
            ConsoleTable.From(wysylki).Write();
        }
        private static void PobierzPismaWgStandardow(PismoService pismoService)
        {
            var pisma = pismoService.PobierzPismaWgStandardow();

            Console.WriteLine("Punkt 2-> Wszystkie pisma priorytetowe, które nie zostały wysłane: {0}", pisma.Count);
            ConsoleTable.From(pisma).Write();
        }
        private static void PobierzLiczbeWyslanychPismWgDnia(PismoService pismoService)
        {
            var liczbeWyslanychPismWgDnia = pismoService.PobierzLiczbeWyslanychPismWgDnia();

            Console.WriteLine("Punkt 3 -> Liczba wyslanych pism wg daty");
            ConsoleTable.From(liczbeWyslanychPismWgDnia).Write();
        }
    }
}