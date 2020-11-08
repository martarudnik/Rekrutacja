using System;
using System.Collections.Generic;
using System.Text;
using Zadanie02.Models;

namespace Zadanie02.Interfaces
{
    public interface IPismoService
    {
        IEnumerable<PismoModel> PobierzWszytskiePisma();
    }
}
