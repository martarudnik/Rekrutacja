/* ***************************************************************************************************** */
/*                                                                                                       */
/* 1) Napisz zapytanie, które wyświetli w sformatowanej tabeli wszystkie dane z encji Pismo.             */
/*    Tabela zawiera jedynie wiersze:                                                                    */
/*    a) nieusunięte                                                                                     */
/*    b) z roku 2020                                                                                     */
/*    c) priorytetowe                                                                                    */
/* 2) Utwórz test jednostkowy (xunit), który przetestuje logikę, która jest w WHERE                      */
/*                                                                                                       */
/* ***************************************************************************************************** */
using ConsoleTables;
using System;
using Zadanie02.Database;
using Zadanie02.Services;

namespace Zadanie02
{
    class Program
    {
        static void Main(string[] args)
        {
            var serwis = new PismoService();
            var pismaWgWytycznych = serwis.PobierzPismaWgStandardow();
            Console.WriteLine("Zadanie 2");
            Console.WriteLine("Wszytkie priorytetowe, nieusuniete pisma z 2020 roku:s");
            ConsoleTable.From<Pismo>(pismaWgWytycznych).Write();
            Console.ReadKey();
        }
    }
}