using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class HistorieCenViewModel
    {
        public ModelNemovitost modelNemovitost { get; set; }
        public IList <HistorieCen> historyCen { get; set; }
    }
}
