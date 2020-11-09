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
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using Zadanie02.Database;
using Zadanie02.Interfaces;
using Zadanie02.Models;
using Zadanie02.Services;

namespace Zadanie02
{
    class Program
    {
        static void Main(string[] args)
        {

            var startup = new Startup();

            var pismoService = startup.Provider.GetRequiredService<IPismoService>(); 

            var pismaWgWytycznych = pismoService.PobierzPismaWgStandardow();
            Console.WriteLine("Zadanie 2");
            Console.WriteLine("Wszytkie priorytetowe, nieusuniete pisma z 2020 roku: ");
            ConsoleTable.From<PismoModel>(pismaWgWytycznych).Write();
            Console.ReadKey();
        }
       
    }
}