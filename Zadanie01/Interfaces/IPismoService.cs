using PobieranieDanychZBazy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PobieranieDanychZBazy.Interfaces
{
    public interface IPismoService
    {
        List<PismoModel> PobierzPismaWgStandardow();
        List<KorespondencjaPismaModel> PobierzWysylkiWgStandardow();
        List<WysylkiModel> PobierzLiczbeWyslanychPismWgDnia();
    }
}
