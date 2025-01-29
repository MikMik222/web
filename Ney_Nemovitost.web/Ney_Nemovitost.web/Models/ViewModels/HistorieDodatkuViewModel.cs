using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class HistorieDodatkuViewModel
    {
        public ModelNemovitost modelNemovitost { get; set; }
        public ModelSmlouva modelSmlouva { get; set; }
        public Najemnik najemnik { get; set; }

        public IList <Dodatek> dodateks { get; set; }
    }
}
