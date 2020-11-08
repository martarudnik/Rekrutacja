using System.Collections.Generic;
using Zadanie01.Models;

namespace Zadanie01.Interfaces
{
    public interface IPismoService
    {
        List<PismoModel> PobierzPismaWgStandardow();
        List<KorespondencjaPismaModel> PobierzWysylkiWgStandardow();
        List<WysylkiModel> PobierzLiczbeWyslanychPismWgDnia();
    }
}
