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
            var pismaWgStanbdardow = serwis.PobierzPismaWgStandardow();
            ConsoleTable.From<Pismo>(pismaWgStanbdardow).Write();
            Console.ReadKey();
        }
    }
}