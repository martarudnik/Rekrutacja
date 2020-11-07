using System;
using System.Collections.Generic;
using Xunit;
using Zadanie03.Service;
using Zadanie03.Models;

namespace Testy
{
    public class Zadanie3Testy
    {
        /* Wersja pierwsza w zasadzie to tak bym przetestowa³a ten problem, porowna³a otrzymane wyniki z oczekiwaniami */
        [Fact]
        public void SprawdzZastepstwa_2Resultaty()
        {
            var data = new DateTime(2020, 1, 10);
            var resulaty = ZastepstwoService.PobierzZastepstwaWgDaty(data, PrzygotujDane());
            Assert.Equal(2, resulaty.Count);
        }

        [Fact]
        public void SprawdzZastepstwa_2Resultaty1()
        {
            var data = new DateTime(2020, 1, 10);
            var resulaty = ZastepstwoService.PobierzZastepstwaWgDaty(data, PrzygotujDane());
            Assert.Equal(2, resulaty.Count);
        }
        [Fact]
        public void SprawdzZastepstwa_3RResultaty()
        {
            var data = new DateTime(2020, 1, 16);
            var resulaty = ZastepstwoService.PobierzZastepstwaWgDaty(data, PrzygotujDane());
            Assert.Equal(3, resulaty.Count);
        }

        private List<Zastepstwo> PrzygotujDane()
        {
            return new List<Zastepstwo>
            {
               new Zastepstwo {Id = 1, DataRozpoczecia = null, DataZakonczenia = null},
               new Zastepstwo {Id = 2, DataRozpoczecia = null, DataZakonczenia = new DateTime(2020, 01, 11)},
               new Zastepstwo {Id = 3, DataRozpoczecia = new DateTime(2020, 1, 14), DataZakonczenia = null},
               new Zastepstwo {Id = 4, DataRozpoczecia = new DateTime(2020, 01, 16), DataZakonczenia = new DateTime(2020, 01, 21)}
            };
        }

        /* Wersja druga przetestowania WHERE.
         * Zeby mieæ pewnosæ, ze warunek w where dzia³a poprawnie, mozna napisaæ warunek w ifie i porównaæ liczbê otrzymanych wyników.
         * Przy doœæ prostym warunku taki if ma sens, ale w przypadku skomplikowanych warunków 
         * trzeba uzyc niezawodej kartki i o³ówka i sobie na spokojnie rozpisac -- przyajmniej ja tak robiê
         */

        [Fact]
        public void SprawdzZastepstwa_2ResultatyWersja2()
        {
            var data = new DateTime(2020, 1, 10);
            var resulaty = ZastepstwoService.PobierzZastepstwaWgDaty(data, PrzygotujDane());
            var resultatyTestu = PobierzZastepstwaNaPodstawieDaty(data, PrzygotujDane());
            Assert.Equal(resultatyTestu.Count, resulaty.Count);
        }

        [Fact]
        public void SprawdzZastepstwa_2Resultaty1Wersja2()
        {
            var data = new DateTime(2020, 1, 10);
            var resulaty = ZastepstwoService.PobierzZastepstwaWgDaty(data, PrzygotujDane());
            var resultatyTestu = PobierzZastepstwaNaPodstawieDaty(data, PrzygotujDane());
            Assert.Equal(resultatyTestu.Count, resulaty.Count);
        }
        [Fact]
        public void SprawdzZastepstwa_3RResultatyWersja2()
        {
            var data = new DateTime(2020, 1, 16);
            var resulaty = ZastepstwoService.PobierzZastepstwaWgDaty(data, PrzygotujDane());
            var resultatyTestu = PobierzZastepstwaNaPodstawieDaty(data, PrzygotujDane());
            Assert.Equal(resultatyTestu.Count, resulaty.Count);
        }

        static List<Zastepstwo> PobierzZastepstwaNaPodstawieDaty(DateTime date, List<Zastepstwo> zastepstwa)
        {
            List<Zastepstwo> temp = new List<Zastepstwo>();
            foreach (var z in zastepstwa)
            {
                if (((z.DataRozpoczecia.HasValue && z.DataRozpoczecia <= date) || (!z.DataRozpoczecia.HasValue))
                && ((z.DataZakonczenia.HasValue && z.DataZakonczenia >= date) || (!z.DataZakonczenia.HasValue)))
                {
                    temp.Add(z);
                }
            }
            return temp;
        }
    }
}
