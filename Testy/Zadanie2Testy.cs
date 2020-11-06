﻿using System.Collections.Generic;
using Xunit;
using Zadanie02.Database;
using Zadanie02.Services;

namespace Testy
{
    public class Zadanie2Testy
    {
        /* Wersja pierwsza w zasadzie to tak bym przetestowała ten problem, porownała otrzymane wyniki z oczekiwaniami */
        [Fact]
        public void SprawdzPismaWgStandardow_Wersja1()
        {
            var service = new PismoService();
            var result = service.PobierzPismaWgStandardow();
            Assert.Equal(1, result.Count);
        }

        /* Wersja druga przetestowania WHERE.
       * Zeby mieć pewnosć, ze warunek w where działa poprawnie, mozna napisać warunek w ifie i porównać liczbę otrzymanych wyników.
       * Przy dość prostym warunku taki if ma sens, ale w przypadku skomplikowanych warunków 
       * trzeba uzyc niezawodej kartki i ołówka i sobie na spokojnie rozpisac -- przyajmniej ja tak robię
       */

        [Fact]
        public void SprawdzPismaWgStandardow_Wersja2()
        {
            var service = new PismoService();
            var pismaWgStandardowZService = service.PobierzPismaWgStandardow();
            var pismaWgStandardowZTestWhere = PobierzPismaWgStandardowTestWhere();

            Assert.Equal(pismaWgStandardowZTestWhere.Count, pismaWgStandardowZService.Count);
        }

        private List<Pismo> PobierzPismaWgStandardowTestWhere()
        {
            var service = new PismoService();
            var wszytkiePisma = service.PobierzWszytskiePisma();
            List<Pismo> pismaWgStandardow = new List<Pismo>();
            
            foreach (var pismo in wszytkiePisma)
            {
                if (!pismo.CzySkasowany && pismo.Priorytet && pismo.Rocznik == 2020)
                {
                    pismaWgStandardow.Add(pismo);
                }
            }
            return pismaWgStandardow;
        }
    }
}