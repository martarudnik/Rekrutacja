using System.Collections.Generic;
using Zadanie02.Models;

namespace Zadanie02.Interfaces
{
    public interface IPismoService
    {
        IList<PismoModel> PobierzWszytskiePisma();
        IList<PismoModel> PobierzPismaWgStandardow();
    }
}