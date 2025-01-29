using Ney_Nemovitost.web.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class DetailNemovitostViewModel
    {
        public ModelNemovitost modelNemovitost { get; set; }
        public int cenaVody { get; set; }
        public int cenaPlynu { get; set; }
        public int cenaElektriky { get; set; }
        public int cenaInternetu { get; set; }
        public int cenaUklidu { get; set; } 
        public int cenaOdpadu { get; set; }
        public int cenaSpolecneEleketriky { get; set; }
    }
}
