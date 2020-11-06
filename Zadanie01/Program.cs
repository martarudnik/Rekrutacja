using Microsoft.EntityFrameworkCore;
using Zadanie01.Database;

namespace Zadanie01
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using var context = new TestContext(options);
            context.Database.EnsureCreated();

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
        }
    }
}